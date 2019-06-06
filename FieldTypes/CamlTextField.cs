using CamlBuilder4000.Internal;

namespace CamlBuilder4000.FieldTypes
{
    public class CamlTextField
    {
        private readonly string fieldName;
        private readonly bool or;
        private readonly CamlOperatorPicker query;

        public override string ToString() => query.ToString();

        internal CamlTextField(CamlOperatorPicker query, bool or, string fieldName)
        {
            this.query = query;
            this.or = or;
            this.fieldName = fieldName;
        }

        public CamlOperatorPicker Equal(string filterValue)
        {
            var newCondition = $@"<Eq><FieldRef Name=""{fieldName}"" /><Value Type=""Text"">{filterValue}</Value></Eq>";

            Helper.NewMethod(or, query, newCondition);

            return query;
        }

        public CamlOperatorPicker IsNotEmpty()
        {
            var newCondition = $@"<And><IsNotNull><FieldRef Name=""{fieldName}"" /></IsNotNull><Neq><FieldRef Name=""{fieldName}"" /><Value Type='Text'></Value></Neq></And>";

            Helper.NewMethod(or, query, newCondition);

            return query;
        }
    }
}
