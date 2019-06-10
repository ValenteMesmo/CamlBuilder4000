using System;

namespace CamlBuilder4000.Internal
{
    public class CamlOperatorPicker
    {
        internal string currentCondition;
        internal bool currentConditionIsOr;
        internal string query = "";
        private readonly bool Root;

        internal CamlOperatorPicker(bool root)
        {
            this.Root = root;
        }

        public CamlFieldPicker And()
        {
            currentConditionIsOr = false;
            return new CamlFieldPicker(this, false);
        }

        public CamlFieldPicker Or()
        {
            currentConditionIsOr = true;
            return new CamlFieldPicker(this, true);
        }

        public CamlFieldPicker And(Action<CamlFieldPicker> internalConditions)
        {
            currentConditionIsOr = false;
            var tempQuery = new CamlOperatorPicker(false);
            internalConditions(new CamlFieldPicker(tempQuery, false));
            Helper.CombineTwoQueries(false, this, tempQuery);
            return new CamlFieldPicker(this, false);
        }

        public CamlFieldPicker Or(Action<CamlFieldPicker> internalConditions)
        {
            currentConditionIsOr = false;
            var tempQuery = new CamlOperatorPicker(false);
            internalConditions(new CamlFieldPicker(tempQuery, true));
            Helper.CombineTwoQueries(true, this, tempQuery);
            return new CamlFieldPicker(this, true);
        }

        /// <summary>
        /// Returns the caml XML as string
        /// </summary>
        public override string ToString()
        {
            if (Root)
            {
                if (currentCondition != null && query == "")
                    return $"<Where>{currentCondition}</Where>";

                if (query == "" && currentCondition == null)
                    return "";
            }

            if (currentCondition != null)
            {
                if (currentConditionIsOr)
                    query = $"<Or>{query}{currentCondition}</Or>";
                else
                    query = $"<And>{query}{currentCondition}</And>";
            }

            if (Root)
                return $"<Where>{query}</Where>";

            return query;
        }
    }
}
