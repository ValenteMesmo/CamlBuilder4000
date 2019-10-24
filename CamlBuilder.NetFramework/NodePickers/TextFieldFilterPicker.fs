namespace ValenteMesmo.CamlQueryBuilder

open System.Runtime.CompilerServices
open ValenteMesmo.CamlQueryBuilder.Internals.PartPicker
open ValenteMesmo.CamlQueryBuilder.Internals.Xml.XmlNodeFactories

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

