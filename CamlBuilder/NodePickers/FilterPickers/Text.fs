namespace ValenteMesmo.CamlQueryBuilder

open ValenteMesmo.CamlQueryBuilder.Internals.Xml.XmlNodeFactories
open ValenteMesmo.CamlQueryBuilder.Internals.PartPicker
open System.Runtime.CompilerServices

[<Extension>]
type TextFieldFilterPickerExtensions =

    [<Extension>]
    static member IsNull(picker: TextFieldFilterPicker) =
        picker.fieldDefinition
        |> createIsNullNode
        |> picker.Build
        |> LogicalOperatorPicker

    [<Extension>]
    static member IsNotNull(picker: TextFieldFilterPicker) =
        picker.fieldDefinition
        |> createIsNotNullNode
        |> picker.Build
        |> LogicalOperatorPicker

    [<Extension>]    
    static member IsEqualTo(picker: TextFieldFilterPicker, value : string) =
        createTextValueNode(value)
        |> concat picker.fieldDefinition
        |> createEqualNode
        |> picker.Build
        |> LogicalOperatorPicker

    [<Extension>]    
    static member IsNotEqualTo(picker: TextFieldFilterPicker, value : string) =
        createTextValueNode(value)
        |> concat picker.fieldDefinition
        |> createNotEqualNode
        |> picker.Build
        |> LogicalOperatorPicker
        

    [<Extension>]    
    static member Contains(picker: TextFieldFilterPicker, value : string) =
        createTextValueNode(value)
        |> concat picker.fieldDefinition
        |> createContainsNode
        |> picker.Build
        |> LogicalOperatorPicker
        
