using CamlBuilder4000.FieldTypes;

namespace CamlBuilder4000.Internal
{
    public class CamlFieldPicker
    {
        private readonly bool or;
        private readonly CamlOperatorPicker query;

        internal CamlFieldPicker(CamlOperatorPicker query, bool or)
        {
            this.query = query;
            this.or = or;
        }

        /// <summary>
        /// Returns the caml XML as string
        /// </summary>
        public override string ToString() => query.ToString();

        public CamlTextField Text(string fieldName) =>
            new CamlTextField(query, or, fieldName);

        public CamlNumberField Number(string fieldName) =>
            new CamlNumberField(query, or, fieldName);

        public CamlDateField Date(string fieldName) =>
            new CamlDateField(query, or, fieldName);

        public CamlLookupIdField LookupId(string fieldName) =>
            new CamlLookupIdField(query, or, fieldName);

        public CamlBoolField Boolean(string fieldName) =>
            new CamlBoolField(query, or, fieldName);
    }
}
