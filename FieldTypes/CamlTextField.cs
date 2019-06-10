using CamlBuilder4000.Internal;

namespace CamlBuilder4000.FieldTypes
{
    public class CamlTextField
    {
        private readonly string fieldName;
        private readonly bool or;
        private readonly CamlOperatorPicker query;

        /// <summary>
        /// Returns the caml XML as string
        /// </summary>
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

            Helper.CombineCurrentQueryWithNewCondition(or, query, newCondition);

            return query;
        }

        public CamlOperatorPicker NotEqual(string filterValue)
        {
            var newCondition = $@"<Neq><FieldRef Name=""{fieldName}"" /><Value Type=""Text"">{filterValue}</Value></Neq>";

            Helper.CombineCurrentQueryWithNewCondition(or, query, newCondition);

            return query;
        }

        public CamlOperatorPicker IsNotEmpty()
        {
            var newCondition = $@"<And><IsNotNull><FieldRef Name=""{fieldName}"" /></IsNotNull><Neq><FieldRef Name=""{fieldName}"" /><Value Type='Text'></Value></Neq></And>";

            Helper.CombineCurrentQueryWithNewCondition(or, query, newCondition);

            return query;
        }

        public CamlOperatorPicker IsEmpty()
        {
            var newCondition = $@"<Or><IsNull><FieldRef Name=""{fieldName}"" /></IsNull><Eq><FieldRef Name=""{fieldName}"" /><Value Type='Text'></Value></Eq></Or>";

            Helper.CombineCurrentQueryWithNewCondition(or, query, newCondition);

            return query;
        }

        public CamlOperatorPicker BeginsWith(string value)
        {
            var newCondition = $@"<BeginsWith><FieldRef Name=""{fieldName}"" /><Value Type=""Text"">{value}</Value></BeginsWith>";

            Helper.CombineCurrentQueryWithNewCondition(or, query, newCondition);

            return query;
        }

        public CamlOperatorPicker Contains(string value)
        {
            var newCondition = $@"<Contains><FieldRef Name=""{fieldName}"" /><Value Type=""Text"">{value}</Value></Contains>";

            Helper.CombineCurrentQueryWithNewCondition(or, query, newCondition);

            return query;
        }
    }
}
