namespace ValenteMesmo.CamlQueryBuilder

open ValenteMesmo.CamlQueryBuilder.Internals.Xml.XmlNodeFactories
open ValenteMesmo.CamlQueryBuilder.Internals.PartPicker
open System.Runtime.CompilerServices

[<Extension>]
type FieldTypePickerExtensions =

    [<Extension>]
    static member Text(picker: FieldTypePicker, fieldName: string) =         
        (picker.Build(), createFieldRef fieldName)
        |> TextFieldFilterPicker

    [<Extension>]
    static member LookupId(picker: FieldTypePicker, fieldName: string) = 
        (picker.Build(), createLookupIdFieldRef fieldName)
        |> LookupFieldFilterPicker

    [<Extension>]
    static member LookupIdMulti(picker: FieldTypePicker, fieldName: string) =
        (picker.Build(), createLookupIdFieldRef fieldName)
        |> LookupMultiFieldFilterPicker

    [<Extension>]
    static member Date(picker: FieldTypePicker, fieldName: string) = 
        (picker.Build(), createFieldRef fieldName)
        |> DateFieldFilterPicker

    [<Extension>]
    static member Bool(picker: FieldTypePicker, fieldName: string) = 
        (picker.Build(), createFieldRef fieldName)
        |> BoolFieldFilterPicker

    [<Extension>]
    static member FileDirRef(picker: FieldTypePicker) = 
        (picker.Build(), createFieldRef "FileDirRef")
        |> FileDirRefFilterPicker

    [<Extension>]
    static member Choice(picker: FieldTypePicker, fieldName: string) =         
        (picker.Build(), createFieldRef fieldName)
        |> ChoiceFieldFilterPicker