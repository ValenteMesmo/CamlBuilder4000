namespace ValenteMesmo.CamlQueryBuilder

open ValenteMesmo.CamlQueryBuilder.Internals.Xml.XmlNodeFactories
open ValenteMesmo.CamlQueryBuilder.Internals.PartPicker
open System.Runtime.CompilerServices

[<Extension>]
type LogicalOperatorPickerExtensions =

    [<Extension>]  
    static member And(picker: LogicalOperatorPicker) =
        picker.Build()
        |> createAndNode
        |> FieldTypePicker

    [<Extension>]  
    static member Or(picker: LogicalOperatorPicker) =
        picker.Build()
        |> createOrNode
        |> FieldTypePicker

    [<Extension>]  
    static member And(picker: LogicalOperatorPicker, handler : FieldTypePicker -> LogicalOperatorPicker) =
        let result = 
            FieldTypePicker(sprintf "%s")
            |> handler

        picker.Build()
        |> createAndNode
        <| result.Build()
        |> LogicalOperatorPicker

    [<Extension>]  
    static member Or(picker: LogicalOperatorPicker, handler : FieldTypePicker -> LogicalOperatorPicker) =
        let result =
            handler
            <| FieldTypePicker(sprintf "%s")

        picker.Build() 
        |> createOrNode 
        <| result.Build()
        |> LogicalOperatorPicker