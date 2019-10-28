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
        new LookupFieldFilterPicker(picker.Build(), createLookupIdFieldRef fieldName) 

    [<Extension>]
    static member LookupIdMulti(picker: FieldTypePicker, fieldName: string) = 
        new LookupMultiFieldFilterPicker(picker.Build(), createLookupIdFieldRef fieldName) 

    [<Extension>]
    static member Date(picker: FieldTypePicker, fieldName: string) = 
        new DateFieldFilterPicker(picker.Build(), createFieldRef fieldName)