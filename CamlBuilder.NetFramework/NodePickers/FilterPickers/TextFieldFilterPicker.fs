namespace ValenteMesmo.CamlQueryBuilder

open ValenteMesmo.CamlQueryBuilder.Internals.Xml.XmlNodeFactories
open ValenteMesmo.CamlQueryBuilder.Internals.PartPicker
open System.Runtime.CompilerServices

[<Extension>]
type TextFieldFilterPickerExtensions =

    [<Extension>]    
    static member IsEqualTo(picker: TextFieldFilterPicker, value : string) = 
        LogicalOperatorPicker(                 
            picker.Build(
                createEqualNode(
                    picker.fieldDefinition 
                    + createTextValueNode(value)
                )
            )
        )

    [<Extension>]    
    static member IsNotEqualTo(picker: TextFieldFilterPicker, value : string) = 
        LogicalOperatorPicker(                 
            picker.Build(
                createNotEqualNode(
                    picker.fieldDefinition 
                    + createTextValueNode(value)
                )
            )
        )

    [<Extension>]    
    static member Contains(picker: TextFieldFilterPicker, value : string) = 
        LogicalOperatorPicker(                 
            picker.Build(
                createContainsNode(
                    picker.fieldDefinition 
                    + createTextValueNode(value)
                )
            )
        )
