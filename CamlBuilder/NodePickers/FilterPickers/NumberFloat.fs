namespace ValenteMesmo.CamlQueryBuilder

open ValenteMesmo.CamlQueryBuilder.Internals.Xml.XmlNodeFactories
open ValenteMesmo.CamlQueryBuilder.Internals.PartPicker
open System.Runtime.CompilerServices

[<Extension>]
type FloatFieldFilterPickerExtensions =

    [<Extension>]    
    static member IsEqualTo(picker: NumberFieldFilterPicker, value : float) =
        createFloatValueNode(value)
        |> concat picker.fieldDefinition
        |> createEqualNode
        |> picker.Build
        |> LogicalOperatorPicker

    [<Extension>]    
    static member IsNotEqualTo(picker: NumberFieldFilterPicker, value : float) =
        createFloatValueNode(value)
        |> concat picker.fieldDefinition
        |> createNotEqualNode
        |> picker.Build
        |> LogicalOperatorPicker

    [<Extension>]
    static member IsGreaterThan(picker: DateFieldFilterPicker, value : float) =
        createFloatValueNode(value)
        |> concat picker.fieldDefinition
        |> createGreaterThanNode
        |> picker.Build
        |> LogicalOperatorPicker

    [<Extension>]
    static member IsLessThan(picker: DateFieldFilterPicker, value : float) =
        createFloatValueNode(value)
        |> concat picker.fieldDefinition
        |> createLessThanNode
        |> picker.Build
        |> LogicalOperatorPicker
        
