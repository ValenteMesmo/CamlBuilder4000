namespace ValenteMesmo.CamlQueryBuilder

open ValenteMesmo.CamlQueryBuilder.Internals.Xml.XmlNodeFactories
open ValenteMesmo.CamlQueryBuilder.Internals.PartPicker
open System.Runtime.CompilerServices

[<Extension>]
type FileDirRefFilterPickerExtensions =

    [<Extension>]
    static member IsEqualTo(picker: FileDirRefFilterPicker, value: string) =
        createPathValueNode(value)
        |> concat picker.fieldDefinition
        |> createEqualNode
        |> picker.Build
        |> LogicalOperatorPicker