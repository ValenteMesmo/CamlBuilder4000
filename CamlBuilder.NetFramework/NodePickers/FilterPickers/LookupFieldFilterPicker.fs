namespace ValenteMesmo.CamlQueryBuilder

open ValenteMesmo.CamlQueryBuilder.Internals.Xml.XmlNodeFactories
open ValenteMesmo.CamlQueryBuilder.Internals.PartPicker
open System.Runtime.CompilerServices

[<Extension>]
type LookupFieldFilterPickerExtensions =

    [<Extension>]
    static member IsNull(picker: LookupFieldFilterPicker) =        
        picker.fieldDefinition
        |> createIsNullNode
        |> picker.Build
        |> LogicalOperatorPicker

    [<Extension>]
    static member IsEqualTo(picker: LookupFieldFilterPicker, value : int) =        
        picker.fieldDefinition + createLookupValueNode(value)
        |> createEqualNode
        |> picker.Build
        |> LogicalOperatorPicker
