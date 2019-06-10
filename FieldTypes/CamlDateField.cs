using CamlBuilder4000.Internal;
using System;

namespace CamlBuilder4000.FieldTypes
{
    /// <summary>
    /// <para>Presents possible filters to Date fields</para>
    /// Examples: <see cref="Between"></see> and <see cref="GreaterThan"></see>
    /// </summary>
    public class CamlDateField
    {
        private CamlOperatorPicker query;
        private bool or;
        private string fieldName;

        /// <summary>
        /// Returns the caml XML as string
        /// </summary>
        public override string ToString() => query.ToString();

        internal CamlDateField(CamlOperatorPicker query, bool or, string fieldName)
        {
            this.query = query;
            this.or = or;
            this.fieldName = fieldName;
        }

        /// <summary>
        /// <para>Example of related xml:</para>
        ///&lt;Geq&gt;<para/>
        ///    &lt;FieldRef Name=&quot;fieldName&quot; /&gt;<para/>
        ///    &lt;Value IncludeTimeValue=&quot;FALSE&quot; Type=&quot;DateTime&quot;&gt;yyyy-MM-ddTHH:mm:ssZ&lt;/Value&gt;<para/>
        ///&lt;/Geq&gt;<para/>
        ///&lt;Leq&gt;<para/>
        ///    &lt;FieldRef Name=&quot;fieldName&quot; /&gt;<para/>
        ///    &lt;Value IncludeTimeValue=&quot;FALSE&quot; Type=&quot;DateTime&quot;&gt;yyyy-MM-ddTHH:mm:ssZ&lt;/Value&gt;<para/>
        ///&lt;/Leq&gt;<para/>
        /// </summary>
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
            Helper.CombineCurrentQueryWithNewCondition(or, query, newCondition);

            return query;
        }

        /// <summary>
        /// <para>Example of related xml:</para>
        ///&lt;Gt&gt;<para/>
        ///    &lt;FieldRef Name=&quot;fieldName&quot; /&gt;<para/>
        ///    &lt;Value IncludeTimeValue=&quot;FALSE&quot; Type=&quot;DateTime&quot;&gt;yyyy-MM-ddTHH:mm:ssZ&lt;/Value&gt;<para/>
        ///&lt;/Gt&gt;<para/>
        /// </summary>
        public CamlOperatorPicker GreaterThan(DateTime date)
        {
            //TODO: test
            var newCondition =
                $@"<Gt>
                    <FieldRef Name=""{fieldName}"" />
                    <Value IncludeTimeValue=""FALSE"" Type=""DateTime"">{date.ToString("yyyy-MM-ddTHH:mm:ssZ")}</Value>
                  </Gt>";
            Helper.CombineCurrentQueryWithNewCondition(or, query, newCondition);

            return query;
        }

        /// <summary>
        /// <para>Example of related xml:</para>
        ///&lt;Lt&gt;<para/>
        ///    &lt;FieldRef Name=&quot;fieldName&quot; /&gt;<para/>
        ///    &lt;Value IncludeTimeValue=&quot;FALSE&quot; Type=&quot;DateTime&quot;&gt;yyyy-MM-ddTHH:mm:ssZ&lt;/Value&gt;<para/>
        ///&lt;/Lt&gt;<para/>
        /// </summary>
        public CamlOperatorPicker LessThan(DateTime date)
        {
            //TODO: test
            var newCondition =
                $@"<Lt>
                    <FieldRef Name=""{fieldName}"" />
                    <Value IncludeTimeValue=""FALSE"" Type=""DateTime"">{date.ToString("yyyy-MM-ddTHH:mm:ssZ")}</Value>
                  </Lt>";
            Helper.CombineCurrentQueryWithNewCondition(or, query, newCondition);

            return query;
        }

        /// <summary>
        /// <para>Example of related xml:</para>
        ///&lt;Leq&gt;<para/>
        ///    &lt;FieldRef Name=&quot;fieldName&quot; /&gt;<para/>
        ///    &lt;Value IncludeTimeValue=&quot;FALSE&quot; Type=&quot;DateTime&quot;&gt;yyyy-MM-ddTHH:mm:ssZ&lt;/Value&gt;<para/>
        ///&lt;/Leq&gt;<para/>
        /// </summary>
        public CamlOperatorPicker LessThanOrEqual(DateTime date)
        {
            //TODO: test
            var newCondition =
                $@"<Leq>
                    <FieldRef Name=""{fieldName}"" />
                    <Value IncludeTimeValue=""FALSE"" Type=""DateTime"">{date.ToString("yyyy-MM-ddTHH:mm:ssZ")}</Value>
                  </Leq>";
            Helper.CombineCurrentQueryWithNewCondition(or, query, newCondition);

            return query;
        }

        /// <summary>
        /// <para>Example of related xml:</para>
        ///&lt;Geq&gt;<para/>
        ///    &lt;FieldRef Name=&quot;fieldName&quot; /&gt;<para/>
        ///    &lt;Value IncludeTimeValue=&quot;FALSE&quot; Type=&quot;DateTime&quot;&gt;yyyy-MM-ddTHH:mm:ssZ&lt;/Value&gt;<para/>
        ///&lt;/Geq&gt;<para/>
        /// </summary>
        public CamlOperatorPicker GreaterThanOrEqual(DateTime date)
        {
            //TODO: test
            var newCondition =
                $@"<Geq>
                    <FieldRef Name=""{fieldName}"" />
                    <Value IncludeTimeValue=""FALSE"" Type=""DateTime"">{date.ToString("yyyy-MM-ddTHH:mm:ssZ")}</Value>
                  </Geq>";
            Helper.CombineCurrentQueryWithNewCondition(or, query, newCondition);

            return query;
        }
    }
}
