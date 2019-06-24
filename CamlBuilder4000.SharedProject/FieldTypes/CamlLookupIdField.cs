using CamlBuilder4000.Internal;

namespace CamlBuilder4000.FieldTypes
{
    /// <summary>
    /// <para>Presents possible filters to Lookup ids</para>
    /// Examples: <see cref="In"></see> and <see cref="Equal"></see>
    /// </summary>
    public class CamlLookupIdField
    {
        private CamlOperatorPicker query;
        private bool or;
        private string fieldName;

        /// <summary>
        /// Returns the caml XML as string
        /// </summary>
        public override string ToString() => query.ToString();

        internal CamlLookupIdField(CamlOperatorPicker query, bool or, string fieldName)
        {
            this.query = query;
            this.or = or;
            this.fieldName = fieldName;
        }

        /// <summary>
        /// <para>Example of related xml:</para>
        ///&lt;In&gt;<para/>
        ///    &lt;FieldRef Name=&quot;fieldName&quot; LookupId=&quot;TRUE&quot; /&gt;<para/>
        ///    &lt;Values&gt;<para/>
        ///        &lt;Value Type=&quot;Lookup&quot;&gt;1&lt;/Value&gt;<para/>
        ///        &lt;Value Type=&quot;Lookup&quot;&gt;2&lt;/Value&gt;<para/>
        ///        &lt;Value Type=&quot;Lookup&quot;&gt;3&lt;/Value&gt;<para/>
        ///    &lt;/Values&gt;<para/>
        ///&lt;/In&gt;<para/>
        /// </summary>
        public CamlOperatorPicker In(params int[] ids)
        {
            var values = "";
            foreach (var item in ids)
                values += $@"<Value Type=""Lookup"">{item}</Value>";

            var newCondition = $@"<In><FieldRef Name=""{fieldName}"" LookupId=""TRUE"" /><Values>{values}</Values></In>";

            Helper.CombineCurrentQueryWithNewCondition(or, query, newCondition);

            return query;
        }

        /// <summary>
        /// <para>Example of related xml:</para>
        /// &lt;Eq&gt;&lt;FieldRef Name=&quot;fieldName&quot; LookupId=&quot;TRUE&quot; /&gt;&lt;Value Type=&quot;Lookup&quot;&gt;999&lt;/Value&gt;&lt;/Eq&gt;
        /// </summary>
        public CamlOperatorPicker Equal(int id)
        {
            var newCondition = $@"<Eq><FieldRef Name=""{fieldName}"" LookupId=""TRUE"" /><Value Type=""Lookup"">{id}</Value></Eq>";

            Helper.CombineCurrentQueryWithNewCondition(or, query, newCondition);

            return query;
        }

        /// <summary>
        /// <para>Example of related xml:</para>
        /// &lt;Neq&gt;&lt;FieldRef Name=&quot;fieldName&quot; LookupId=&quot;TRUE&quot; /&gt;&lt;Value Type=&quot;Lookup&quot;&gt;999&lt;/Value&gt;&lt;/Neq&gt;
        /// </summary>
        public CamlOperatorPicker NotEqual(int id)
        {
            var newCondition = $@"<Neq><FieldRef Name=""{fieldName}"" LookupId=""TRUE"" /><Value Type=""Lookup"">{id}</Value></Neq>";

            Helper.CombineCurrentQueryWithNewCondition(or, query, newCondition);

            return query;
        }

        public CamlOperatorPicker IsNull()
        {
            var newCondition = $@"<IsNull><FieldRef Name=""{fieldName}"" LookupId=""TRUE"" /></IsNull>";

            Helper.CombineCurrentQueryWithNewCondition(or, query, newCondition);

            return query;
        }

        public CamlOperatorPicker IsNotNull()
        {
            var newCondition = $@"<IsNotNull><FieldRef Name=""{fieldName}"" LookupId=""TRUE"" /></IsNotNull>";

            Helper.CombineCurrentQueryWithNewCondition(or, query, newCondition);

            return query;
        }
    }
}
