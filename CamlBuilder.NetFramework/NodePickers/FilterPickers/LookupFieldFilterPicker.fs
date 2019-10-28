namespace ValenteMesmo.CamlQueryBuilder

open ValenteMesmo.CamlQueryBuilder.Internals.Xml.XmlNodeFactories
open ValenteMesmo.CamlQueryBuilder.Internals.PartPicker
open System.Runtime.CompilerServices

[<Extension>]
type LookupFieldFilterPickerExtensions =

    [<Extension>]
    static member IsNull(picker: LookupFieldFilterPicker) =
        new LogicalOperatorPicker(
            picker.fieldDefinition
            |> createIsNullNode
            |> picker.Build
        )

    [<Extension>]
    static member IsEqualTo(picker: LookupFieldFilterPicker, value : int) =
        new LogicalOperatorPicker(
            picker.fieldDefinition + createLookupValueNode(value)
            |> createEqualNode
            |> picker.Build
        )