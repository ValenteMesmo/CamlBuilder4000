namespace ValenteMesmo.CamlQueryBuilder

open ValenteMesmo.CamlQueryBuilder.Internals.Xml.XmlNodeFactories
open ValenteMesmo.CamlQueryBuilder.Internals.PartPicker
open System.Runtime.CompilerServices

[<Extension>]
type LookupMultiFieldFilterPickerExtensions =

    [<Extension>]
    static member IsNull(picker: LookupMultiFieldFilterPicker) =
        new LogicalOperatorPicker(
            picker.fieldDefinition
            |> createIsNullNode
            |> picker.Build
        )

    [<Extension>]
    static member Contains(picker: LookupMultiFieldFilterPicker, value : int) =
        new LogicalOperatorPicker(
            picker.fieldDefinition + createLookupValueNode(value)
            |> createEqualNode
            |> picker.Build
        )