using CamlBuilder4000.Internal;
using System;

namespace CamlBuilder4000.FieldTypes
{
    public class CamlDateField
    {
        private CamlOperatorPicker query;
        private bool or;
        private string fieldName;

        /// <summary>
        /// Returns the caml XML as string
        /// </summary>
        public override string ToString() => query.ToString();

        public CamlDateField(CamlOperatorPicker query, bool or, string fieldName)
        {
            this.query = query;
            this.or = or;
            this.fieldName = fieldName;
        }

        public CamlOperatorPicker Between(DateTime from, DateTime to)
        {
            //TODO: test
            var newCondition =
            $@"<Geq>
                <FieldRef Name=""{fieldName}"" />
                <Value IncludeTimeValue=""FALSE"" Type=""DateTime"">{from.ToString("yyyy-MM-ddTHH:mm:ssZ")}</Value>
              </Geq>
              <Leq>
                <FieldRef Name=""{fieldName}"" />
                <Value IncludeTimeValue=""FALSE"" Type=""DateTime"">{to.ToString("yyyy-MM-ddTHH:mm:ssZ")}</Value>
              </Leq>";
            Helper.NewMethod(or, query, newCondition);

            return query;
        }

        public CamlOperatorPicker GreaterThan(DateTime date)
        {
            //TODO: test
            var newCondition =
            $@"<Gt>
                <FieldRef Name=""{fieldName}"" />
                <Value IncludeTimeValue=""FALSE"" Type=""DateTime"">{date.ToString("yyyy-MM-ddTHH:mm:ssZ")}</Value>
              </Gt>";
            Helper.NewMethod(or, query, newCondition);

            return query;
        }
    }
}
