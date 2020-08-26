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
    static member And(picker: LogicalOperatorPicker, handler : System.Func<FieldTypePicker, LogicalOperatorPicker>) =
        let result = 
            FieldTypePicker(sprintf "%s")
            |> handler.Invoke

        picker.Build()
        |> createAndNode
        <| result.Build()
        |> LogicalOperatorPicker

    [<Extension>]  
    static member Or(picker: LogicalOperatorPicker, handler : System.Func<FieldTypePicker, LogicalOperatorPicker>) =
        let result =
            handler.Invoke
            <| FieldTypePicker(sprintf "%s")

        picker.Build() 
        |> createOrNode 
        <| result.Build()
        |> LogicalOperatorPicker