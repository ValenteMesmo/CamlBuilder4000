namespace ValenteMesmo.CamlQueryBuilder

open ValenteMesmo.CamlQueryBuilder.Internals.Xml.XmlNodeFactories
open ValenteMesmo.CamlQueryBuilder.Internals.PartPicker
open System.Runtime.CompilerServices

[<Extension>]
type DateFieldFilterPickerExtensions =

    [<Extension>]
    static member IsNull(picker: DateFieldFilterPicker) =
        new LogicalOperatorPicker(
            picker.fieldDefinition
            |> createIsNullNode
            |> picker.Build
        )

    [<Extension>]
    static member IsLessThan (picker: DateFieldFilterPicker, value : System.DateTime) = 
        LogicalOperatorPicker(
            picker.fieldDefinition + createDateOnlyValue(value)
            |> createLessThanNode
            |> picker.Build
        )