using CamlBuilder4000.Internal;

namespace CamlBuilder4000.FieldTypes
{
    public class CamlNumberField
    {
        private CamlOperatorPicker query;
        private bool or;
        private string fieldName;

        /// <summary>
        /// Returns the caml XML as string
        /// </summary>
        public override string ToString() => query.ToString();

        internal CamlNumberField(CamlOperatorPicker query, bool or, string fieldName)
        {
            this.query = query;
            this.or = or;
            this.fieldName = fieldName;
        }

        public CamlOperatorPicker GreaterThan(int filterValue)
        {
            var newCondition = $@"<Gt><FieldRef Name=""{fieldName}"" /><Value Type=""Number"">{filterValue}</Value></Gt>";

            Helper.CombineCurrentQueryWithNewCondition(or, query, newCondition);

            return query;
        }

        public CamlOperatorPicker LessThan(int filterValue)
        {
            var newCondition = $@"<Lt><FieldRef Name=""{fieldName}"" /><Value Type=""Number"">{filterValue}</Value></Lt>";

            Helper.CombineCurrentQueryWithNewCondition(or, query, newCondition);

            return query;
        }

        public CamlOperatorPicker GreaterThanOrEqual(int filterValue)
        {
            var newCondition = $@"<Geq><FieldRef Name=""{fieldName}"" /><Value Type=""Number"">{filterValue}</Value></Geq>";

            Helper.CombineCurrentQueryWithNewCondition(or, query, newCondition);

            return query;
        }

        public CamlOperatorPicker LessThanOrEqual(int filterValue)
        {
            var newCondition = $@"<Leq><FieldRef Name=""{fieldName}"" /><Value Type=""Number"">{filterValue}</Value></Leq>";

            Helper.CombineCurrentQueryWithNewCondition(or, query, newCondition);

            return query;
        }

        public CamlOperatorPicker Equal(int value)
        {
            var newCondition = $@"<Eq><FieldRef Name=""{fieldName}"" /><Value Type=""Number"">{value}</Value></Eq>";

            Helper.CombineCurrentQueryWithNewCondition(or, query, newCondition);

            return query;
        }

        public CamlOperatorPicker NotEqual(int value)
        {
            var newCondition = $@"<Neq><FieldRef Name=""{fieldName}"" /><Value Type=""Number"">{value}</Value></Neq>";

            Helper.CombineCurrentQueryWithNewCondition(or, query, newCondition);

            return query;
        }

        public CamlOperatorPicker IsNull()
        {
            var newCondition = $@"<IsNull><FieldRef Name=""{fieldName}"" /></IsNull>";

            Helper.CombineCurrentQueryWithNewCondition(or, query, newCondition);

            return query;
        }

        public CamlOperatorPicker IsNotNull()
        {
            var newCondition = $@"<IsNotNull><FieldRef Name=""{fieldName}"" /></IsNotNull>";

            Helper.CombineCurrentQueryWithNewCondition(or, query, newCondition);

            return query;
        }
    }
}
