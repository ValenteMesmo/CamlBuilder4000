namespace ValenteMesmo.CamlQueryBuilder

open ValenteMesmo.CamlQueryBuilder.Internals.Xml.XmlNodeFactories
open ValenteMesmo.CamlQueryBuilder.Internals.PartPicker
open System.Runtime.CompilerServices
open System

[<Extension>]
type LookupIdFieldFilterPickerExtensions =

    //TODO: test this.... i dont thing in exists on lookup field filter
    [<Extension>]
    static member IsIn (picker: LookupIdFieldFilterPicker, [<ParamArray>] values : int array) = 
        let createNode value = createLookupValueNode value
        let formattedValues = 
            values 
            |> Array.map createNode 
            |> System.String.Concat

        LogicalOperatorPicker(                 
            createInNode(picker.fieldDefinition + createValuesNode(formattedValues))
            |> picker.Build
        )