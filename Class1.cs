using System;

namespace CamlBuilder4000
{
    public class CamlQueryFilterPicker
    {
        private readonly bool or;
        private readonly CamlBuilder query;

        internal CamlQueryFilterPicker(CamlBuilder query, bool or)
        {
            this.query = query;
            this.or = or;
        }

        public CamlBuilder TextEqual(string fieldName, string filterValue)
        {
            var newCondition = $@"<Eq><FieldRef Name=""{fieldName}"" /><Value Type=""Text"">{filterValue}</Value></Eq>";

            NewMethod(or, query, newCondition);

            return query;
        }

        public CamlBuilder TextIsNotEmpty(string fieldName)
        {
            var newCondition = $@"<And><IsNotNull><FieldRef Name=""{fieldName}"" /></IsNotNull><Neq><FieldRef Name=""{fieldName}"" /><Value Type='Text'></Value></Neq></And>";

            NewMethod(or, query, newCondition);

            return query;
        }

        public CamlBuilder NumberGreaterThan(string fieldName, int filterValue)
        {
            var newCondition = $@"<Gt><FieldRef Name=""{fieldName}"" /><Value Type=""Number"">{filterValue}</Value></Gt>";

            NewMethod(or, query, newCondition);

            return query;
        }

        public CamlBuilder DateBetween(string fieldName, DateTime from, DateTime to)
        {
            //TODO: test
            var newCondition =
            $@"<Geq>
                <FieldRef Name=""StartDate"" />
                  <Value IncludeTimeValue=""TRUE"" Type=""DateTime"">{from.ToString("s")}</Value>
              </Geq>
              <Leq>
                <FieldRef Name=""StartDate"" />
                <Value IncludeTimeValue=""TRUE"" Type=""DateTime"">{to.ToString("s")}</Value>
              </Leq>";
            NewMethod(or, query, newCondition);

            return query;
        }

        public CamlBuilder LookupIdIn(string fieldName, params int[] filterValues)
        {
            var values = "";
            foreach (var item in filterValues)
            {
                values += $@"<Value Type=""Lookup"">{item}</Value>";
            }
            var newCondition = $@"<In><FieldRef Name=""{fieldName}"" LookupId=""TRUE"" /><Values>{values}</Values></In>";

            NewMethod(or, query, newCondition);

            return query;
        }

        public CamlBuilder BooleanEqual(string fieldName, bool filterValue)
        {
            var newCondition = $@"<Eq><FieldRef Name=""{fieldName}"" /><Value Type=""Boolean"">{(filterValue ? 1 : 0)}</Value></Eq>";

            NewMethod(or, query, newCondition);

            return query;
        }

        internal static void NewMethod(bool or, CamlBuilder query, CamlBuilder query2)
        {
            var newCondition = "";
            if (query.currentCondition != null && query.query == "")
                newCondition = query.currentCondition;
            else
                newCondition = query.query;

            if (or)
                query.query = $@"<Or>{newCondition}{query2}</Or>";
            else
                query.query = $@"<And>{newCondition}{query2}</And>";

            query.currentCondition = null;
        }

        internal static void NewMethod(bool or, CamlBuilder query, string newCondition)
        {
            if (query.currentCondition == null)
                query.currentCondition = newCondition;
            else
            {
                var currentQuery = query.query;
                if (currentQuery != "")
                {
                    if (query.currentCondition != null)
                    {
                        if (query.currentConditionIsOr)
                            currentQuery = $@"<Or>{currentQuery}{query.currentCondition}</Or>";
                        else
                            currentQuery = $@"<And>{currentQuery}{query.currentCondition}</And>";

                        query.currentCondition = null;
                    }
                }
                else {
                    if (query.currentCondition != null)
                    {
                            currentQuery = query.currentCondition;

                        query.currentCondition = null;
                    }
                }
                
                if (or)
                    query.query = $@"<Or>{currentQuery}{newCondition}</Or>";
                else
                    query.query = $@"<And>{currentQuery}{newCondition}</And>";
            }
        }

        public override string ToString()
        {
            return query.ToString();
        }
    }

    public class CamlBuilder
    {
        internal string currentCondition;
        internal bool currentConditionIsOr;
        internal string query = "";
        private readonly bool Root;

        private CamlBuilder(bool root)
        {
            this.Root = root;
        }

        public static CamlQueryFilterPicker Start()
        {
            return new CamlQueryFilterPicker(new CamlBuilder(true), false);
        }

        public CamlQueryFilterPicker And()
        {
            currentConditionIsOr = false;
            return new CamlQueryFilterPicker(this, false);
        }

        public CamlQueryFilterPicker Or()
        {
            currentConditionIsOr = true;
            return new CamlQueryFilterPicker(this, true);
        }

        public CamlQueryFilterPicker And(Action<CamlQueryFilterPicker> internalConditions)
        {
            currentConditionIsOr = false;
            var tempQuery = new CamlBuilder(false);
            internalConditions(new CamlQueryFilterPicker(tempQuery, false));
            CamlQueryFilterPicker.NewMethod(false, this, tempQuery);
            return new CamlQueryFilterPicker(this, false);
        }

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
