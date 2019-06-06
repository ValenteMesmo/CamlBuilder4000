namespace CamlBuilder4000
{
    public static class CamlBuilder
    {
        public static Internal.CamlFieldPicker Start()
        {
            return new Internal.CamlFieldPicker(
                new Internal.CamlOperatorPicker(true)
                , false
            );
        }
    }
}
