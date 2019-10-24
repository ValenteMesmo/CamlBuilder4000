namespace ValenteMesmo.CamlQueryBuilder.Internals.PartPicker

open ValenteMesmo.CamlQueryBuilder.Internals.Xml.XmlNodeFactories
open System

type LogicalOperatorPicker(parentBuild) =
    member internal this.Build() =
        parentBuild

type FieldTypePicker(parentBuild : string -> string) =
    member internal this.Build() =
        parentBuild

type TextFieldFilterPicker(parentBuild : string -> string, fieldDefinition : string) =
    member internal this.Build(a) =
        parentBuild a

    member internal this.fieldDefinition = 
        fieldDefinition 

type LookupIdFieldFilterPicker(parentBuild : string -> string, fieldDefinition) =        
    member this.IsIn ([<ParamArray>] values : int array) = 
        let createNode value = createLookupValueNode value
        let formattedValues = 
            values 
            |> Array.map createNode 
            |> System.String.Concat

        LogicalOperatorPicker(                 
            createInNode(fieldDefinition + createValuesNode(formattedValues))
            |> parentBuild                     
        )

type DateFieldFilterPicker(parentBuild : string -> string, fieldDefinition) =        
    member this.IsLessThan (value : System.DateTime) = 
        LogicalOperatorPicker(                 
            parentBuild                     
                <| createLessThanNode(fieldDefinition + createDateOnlyValue(value))
        )

    member this.IsNull() =
        LogicalOperatorPicker(                 
            parentBuild                     
                <| createIsNullNode fieldDefinition
        )