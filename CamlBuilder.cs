namespace CamlBuilder4000
{
    /// <summary>
    /// <para>Entry point of caml query building!</para>
    /// <para><see cref="CamlBuilder.Start()"/></para>
    /// </summary>
    public static class CamlBuilder
    {
        /// <summary>
        /// github.com/ValenteMesmo/CamlBuilder4000
        /// </summary>
        /// <returns>asdsad</returns>
        public static Internal.CamlFieldPicker Start()
        {
            return new Internal.CamlFieldPicker(
                new Internal.CamlOperatorPicker(true)
                , false
            );
        }
    }
}
