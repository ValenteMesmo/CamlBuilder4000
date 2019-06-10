namespace CamlBuilder4000
{
    /// <summary>
    /// <para>Entry point of caml query building!</para>
    /// <para><see cref="Start()"/></para>
    /// </summary>
    public static class CamlBuilder
    {
        /// <summary>
        /// <para>github.com/ValenteMesmo/CamlBuilder4000</para>
        /// <para>Intellisense should guide you...</para>
        /// <para>Example: <code>CamlBuilder.Start().Text("field1").Equal(2)</code></para>
        /// <para>Don't forget to call <see cref="object.ToString()"/> at the end!</para>
        /// </summary>
        public static Internal.CamlFieldPicker Start()
        {
            return new Internal.CamlFieldPicker(
                new Internal.CamlOperatorPicker(true)
                , false
            );
        }
    }
}
