using CamlBuilder4000.Internal;

namespace CamlBuilder4000.FieldTypes
{
    public class CamlNumberField
    {
        private CamlOperatorPicker query;
        private bool or;
        private string fieldName;

        public override string ToString() => query.ToString();

        public CamlNumberField(CamlOperatorPicker query, bool or, string fieldName)
        {
            this.query = query;
            this.or = or;
            this.fieldName = fieldName;
        }

        public CamlOperatorPicker GreaterThan(int filterValue)
        {
            var newCondition = $@"<Gt><FieldRef Name=""{fieldName}"" /><Value Type=""Number"">{filterValue}</Value></Gt>";

            Helper.NewMethod(or, query, newCondition);

            return query;
        }
    }
}
