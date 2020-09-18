namespace ValenteMesmo.CamlQueryBuilder

open ValenteMesmo.CamlQueryBuilder.Internals.Xml.XmlNodeFactories
open ValenteMesmo.CamlQueryBuilder.Internals.PartPicker
open System.Runtime.CompilerServices

[<Extension>]
type LookupMultiFieldFilterPickerExtensions =

    [<Extension>]
    static member IsNull(picker: LookupMultiFieldFilterPicker) =        
        picker.fieldDefinition
        |> createIsNullNode
        |> picker.Build
        |> LogicalOperatorPicker

    [<Extension>]
    static member IsNotNull(picker: LookupMultiFieldFilterPicker) =
        picker.fieldDefinition
        |> createIsNotNullNode
        |> picker.Build
        |> LogicalOperatorPicker

    [<Extension>]
    static member Contains(picker: LookupMultiFieldFilterPicker, value : int) =        
        createLookupIntValueNode(value)
        |> concat picker.fieldDefinition
        |> createEqualNode
        |> picker.Build
        |> LogicalOperatorPicker