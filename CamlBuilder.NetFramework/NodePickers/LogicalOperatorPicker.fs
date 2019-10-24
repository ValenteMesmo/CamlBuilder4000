namespace ValenteMesmo.CamlQueryBuilder

open ValenteMesmo.CamlQueryBuilder.Internals.Xml.XmlNodeFactories
open ValenteMesmo.CamlQueryBuilder.Internals.PartPicker
open System.Runtime.CompilerServices

[<Extension>]
type LogicalOperatorPickerExtensions =

    [<Extension>]  
    static member And(picker: LogicalOperatorPicker) =
        new FieldTypePicker(createAndNode <| picker.Build())

    [<Extension>]  
    static member Or(picker: LogicalOperatorPicker) =
        new FieldTypePicker(createOrNode <| picker.Build())

    [<Extension>]  
    static member And(picker: LogicalOperatorPicker, handler : FieldTypePicker -> LogicalOperatorPicker) =
        let result = handler(new FieldTypePicker(sprintf "%s"))
        new LogicalOperatorPicker(
            picker.Build() |> createAndNode <| result.Build()
        )