namespace ValenteMesmo.CamlQueryBuilder

open ValenteMesmo.CamlQueryBuilder.Internals.Xml.XmlNodeFactories
open ValenteMesmo.CamlQueryBuilder.Internals.PartPicker
open System.Runtime.CompilerServices

[<Extension>]
type DateFieldFilterPickerExtensions =

    [<Extension>]
    static member IsNull(picker: DateFieldFilterPicker) =
        picker.fieldDefinition
        |> createIsNullNode
        |> picker.Build
        |> LogicalOperatorPicker

    [<Extension>]
    static member IsNotNull(picker: DateFieldFilterPicker) =
        picker.fieldDefinition
        |> createIsNotNullNode
        |> picker.Build
        |> LogicalOperatorPicker

    [<Extension>]
    static member IsLessThan (picker: DateFieldFilterPicker, value : System.DateTime) =
        createDateOnlyValue(value)
        |> concat picker.fieldDefinition
        |> createLessThanNode
        |> picker.Build
        |> LogicalOperatorPicker

    [<Extension>]
    static member IsGreaterThan (picker: DateFieldFilterPicker, value : System.DateTime) =
        createDateOnlyValue(value)
        |> concat picker.fieldDefinition
        |> createGreaterThanNode
        |> picker.Build
        |> LogicalOperatorPicker

    [<Extension>]
    static member IsEqualTo (picker: DateFieldFilterPicker, value : System.DateTime) =
        createDateOnlyValue(value)
        |> concat picker.fieldDefinition
        |> createEqualNode
        |> picker.Build
        |> LogicalOperatorPicker

    [<Extension>]
    static member IsNotEqualTo (picker: DateFieldFilterPicker, value : System.DateTime) =
        createDateOnlyValue(value)
        |> concat picker.fieldDefinition
        |> createNotEqualNode
        |> picker.Build
        |> LogicalOperatorPicker