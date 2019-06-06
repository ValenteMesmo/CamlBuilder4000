using CamlBuilder4000.Internal;
using System;

namespace CamlBuilder4000.FieldTypes
{
    public class CamlDateField
    {
        private CamlOperatorPicker query;
        private bool or;
        private string fieldName;

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
                  <Value IncludeTimeValue=""TRUE"" Type=""DateTime"">{from.ToString("s")}</Value>
              </Geq>
              <Leq>
                <FieldRef Name=""{fieldName}"" />
                <Value IncludeTimeValue=""TRUE"" Type=""DateTime"">{to.ToString("s")}</Value>
              </Leq>";
            Helper.NewMethod(or, query, newCondition);

            return query;
        }
    }
}
