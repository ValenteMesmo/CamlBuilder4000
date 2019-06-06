using CamlBuilder4000.Internal;

namespace CamlBuilder4000.FieldTypes
{
    public class CamlBoolField
    {
        private CamlOperatorPicker query;
        private bool or;
        private string fieldName;

        public override string ToString() => query.ToString();

        public CamlBoolField(CamlOperatorPicker query, bool or, string fieldName)
        {
            this.query = query;
            this.or = or;
            this.fieldName = fieldName;
        }

        public CamlOperatorPicker Equal(bool filterValue)
        {
            var newCondition = $@"<Eq><FieldRef Name=""{fieldName}"" /><Value Type=""Boolean"">{(filterValue ? 1 : 0)}</Value></Eq>";

            Helper.NewMethod(or, query, newCondition);

            return query;
        }
    }
}
