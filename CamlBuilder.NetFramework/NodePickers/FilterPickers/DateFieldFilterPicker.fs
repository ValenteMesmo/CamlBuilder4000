namespace ValenteMesmo.CamlQueryBuilder

open ValenteMesmo.CamlQueryBuilder.Internals.Xml.XmlNodeFactories
open ValenteMesmo.CamlQueryBuilder.Internals.PartPicker
open System.Runtime.CompilerServices

[<Extension>]
type DateFieldFilterPickerExtensions =

    [<Extension>]
    static member IsLessThan (picker: DateFieldFilterPicker, value : System.DateTime) = 
        LogicalOperatorPicker(                 
            picker.Build                     
                <| createLessThanNode(picker.fieldDefinition + createDateOnlyValue(value))
        )

    [<Extension>]
    static member IsNull(picker: DateFieldFilterPicker) =
        LogicalOperatorPicker(                 
            picker.Build
                <| createIsNullNode picker.fieldDefinition
        )