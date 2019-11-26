namespace ValenteMesmo.CamlQueryBuilder

open ValenteMesmo.CamlQueryBuilder.Internals.Xml.XmlNodeFactories
open ValenteMesmo.CamlQueryBuilder.Internals.PartPicker
open System.Runtime.CompilerServices

[<Extension>]
type ChoiceFieldFilterPickerExtensions =

    [<Extension>]
    static member IsNull(picker: ChoiceFieldFilterPicker) =
        picker.fieldDefinition
        |> createIsNullNode
        |> picker.Build
        |> LogicalOperatorPicker

    [<Extension>]
    static member IsNotNull(picker: ChoiceFieldFilterPicker) =
        picker.fieldDefinition
        |> createIsNotNullNode
        |> picker.Build
        |> LogicalOperatorPicker

    [<Extension>]    
    static member IsEqualTo(picker: ChoiceFieldFilterPicker, value : string) =
        createTextValueNode(value)
        |> concat picker.fieldDefinition
        |> createEqualNode
        |> picker.Build
        |> LogicalOperatorPicker

    [<Extension>]    
    static member IsNotEqualTo(picker: ChoiceFieldFilterPicker, value : string) =
        createTextValueNode(value)
        |> concat picker.fieldDefinition
        |> createNotEqualNode
        |> picker.Build
        |> LogicalOperatorPicker
        

    [<Extension>]    
    static member Contains(picker: ChoiceFieldFilterPicker, value : string) =
        createTextValueNode(value)
        |> concat picker.fieldDefinition
        |> createContainsNode
        |> picker.Build
        |> LogicalOperatorPicker
        
