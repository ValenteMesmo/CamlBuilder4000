namespace ValenteMesmo.CamlQueryBuilder

open ValenteMesmo.CamlQueryBuilder.Internals.Xml.XmlNodeFactories
open ValenteMesmo.CamlQueryBuilder.Internals.PartPicker
open System.Runtime.CompilerServices
open System

[<Extension>]
type UniqueIdFilterPickerExtensions =

    [<Extension>]
    static member IsEqualTo(picker: UniqueIdFilterPicker, value: Guid) =
        createLookupGuidValueNode(value)
        |> concat picker.fieldDefinition
        |> createEqualNode
        |> picker.Build
        |> LogicalOperatorPicker

    [<Extension>]
    static member IsEqualTo(picker: UniqueIdFilterPicker, value: string) =
        createLookupStringValueNode(value)
        |> concat picker.fieldDefinition
        |> createEqualNode
        |> picker.Build
        |> LogicalOperatorPicker