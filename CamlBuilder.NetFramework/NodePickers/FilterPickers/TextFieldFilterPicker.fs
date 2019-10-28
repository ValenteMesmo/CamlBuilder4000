namespace ValenteMesmo.CamlQueryBuilder

open ValenteMesmo.CamlQueryBuilder.Internals.Xml.XmlNodeFactories
open ValenteMesmo.CamlQueryBuilder.Internals.PartPicker
open System.Runtime.CompilerServices

[<Extension>]
type TextFieldFilterPickerExtensions =

    [<Extension>]
    static member IsNull(picker: TextFieldFilterPicker) =
        new LogicalOperatorPicker(
            picker.fieldDefinition
            |> createIsNullNode
            |> picker.Build
        )

    [<Extension>]    
    static member IsEqualTo(picker: TextFieldFilterPicker, value : string) = 
        LogicalOperatorPicker(                 
            picker.fieldDefinition + createTextValueNode(value)
            |> createEqualNode
            |> picker.Build
        )

    [<Extension>]    
    static member IsNotEqualTo(picker: TextFieldFilterPicker, value : string) = 
        LogicalOperatorPicker(
            picker.fieldDefinition + createTextValueNode(value)
            |> createNotEqualNode
            |> picker.Build
        )

    [<Extension>]    
    static member Contains(picker: TextFieldFilterPicker, value : string) = 
        LogicalOperatorPicker(
            picker.fieldDefinition + createTextValueNode(value)
            |> createContainsNode
            |> picker.Build
        )
