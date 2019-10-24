namespace ValenteMesmo.CamlQueryBuilder

open ValenteMesmo.CamlQueryBuilder.Internals.Xml.XmlNodeFactories
open ValenteMesmo.CamlQueryBuilder.Internals.PartPicker
open System.Runtime.CompilerServices

[<Extension>]
type FieldTypePickerExtensions =

    [<Extension>]
    static member Text(picker: FieldTypePicker, fieldName: string) = 
        new TextFieldFilterPicker(picker.Build(), createFieldRef fieldName)

    [<Extension>]
    static member LookupId(picker: FieldTypePicker, fieldName: string) = 
        new LookupIdFieldFilterPicker(picker.Build(), createLookupIdFieldRef fieldName) 

    [<Extension>]
    static member Date(picker: FieldTypePicker, fieldName: string) = 
        new DateFieldFilterPicker(picker.Build(), createFieldRef fieldName)