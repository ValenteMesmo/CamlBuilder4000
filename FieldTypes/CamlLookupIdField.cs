using CamlBuilder4000.Internal;

namespace CamlBuilder4000.FieldTypes
{
    public class CamlLookupIdField
    {
        private CamlOperatorPicker query;
        private bool or;
        private string fieldName;

        public override string ToString() => query.ToString();

        public CamlLookupIdField(CamlOperatorPicker query, bool or, string fieldName)
        {
            this.query = query;
            this.or = or;
            this.fieldName = fieldName;
        }

        public CamlOperatorPicker In(params int[] filterValues)
        {
            var values = "";
            foreach (var item in filterValues)
            {
                values += $@"<Value Type=""Lookup"">{item}</Value>";
            }
            var newCondition = $@"<In><FieldRef Name=""{fieldName}"" LookupId=""TRUE"" /><Values>{values}</Values></In>";

            Helper.NewMethod(or, query, newCondition);

            return query;
        }
    }
}
