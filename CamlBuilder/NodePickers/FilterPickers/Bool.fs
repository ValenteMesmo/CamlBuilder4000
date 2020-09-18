namespace ValenteMesmo.CamlQueryBuilder

open ValenteMesmo.CamlQueryBuilder.Internals.Xml.XmlNodeFactories
open ValenteMesmo.CamlQueryBuilder.Internals.PartPicker
open System.Runtime.CompilerServices

[<Extension>]
type BoolFieldFilterPickerExtensions =

    [<Extension>]
    static member IsNull(picker: BoolFieldFilterPicker) =        
        picker.fieldDefinition
        |> createIsNullNode
        |> picker.Build
        |> LogicalOperatorPicker

    [<Extension>]
    static member IsNotNull(picker: BoolFieldFilterPicker) =
        picker.fieldDefinition
        |> createIsNotNullNode
        |> picker.Build
        |> LogicalOperatorPicker

    [<Extension>]
    static member IsEqualTo(picker: BoolFieldFilterPicker, value: bool) =
        createBoolValueNode(value)
        |> concat picker.fieldDefinition
        |> createEqualNode
        |> picker.Build
        |> LogicalOperatorPicker

    [<Extension>]
    static member IsTrue(picker: BoolFieldFilterPicker) =
        picker.IsEqualTo(true)

    [<Extension>]
    static member IsFalse(picker: BoolFieldFilterPicker) =
        picker.IsEqualTo(false)