namespace ValenteMesmo.Internals.PartPicker

open System
open ValenteMesmo.Internals.Xml.XmlNodeFactories

type LogicalOperatorPicker(parentBuild) =
    member this.Build =
        parentBuild

    member this.And() =
        new FieldTypePicker(createAndNode parentBuild)

    member this.Or() =
        new FieldTypePicker(createOrNode parentBuild)

    member this.And(handler : FieldTypePicker -> LogicalOperatorPicker) =
        let result = handler(new FieldTypePicker(sprintf "%s"))
        new LogicalOperatorPicker(createAndNode parentBuild result.Build)

and FieldTypePicker(parentBuild : string -> string) =
    member this.Build =
        parentBuild

    member this.Text fieldName = 
        new TextFieldFilterPicker(this.Build, sprintf "<FieldRef Name='%s'/>" fieldName) 

    member this.LookupId fieldName = 
        new LookupIdFieldFilterPicker(this.Build, sprintf "<FieldRef Name='%s' LookupId='TRUE'/>" fieldName) 

    member this.Date fieldName = 
        new DateFieldFilterPicker(this.Build, sprintf "<FieldRef Name='%s'/>" fieldName) 

and TextFieldFilterPicker(parentBuild : string -> string, fieldDefinition) =        
    member this.IsEqualTo value = 
        LogicalOperatorPicker(                 
            parentBuild                     
                <| createEqualNode(fieldDefinition + createTextValueNode(value))
        )

and LookupIdFieldFilterPicker(parentBuild : string -> string, fieldDefinition) =        
    member this.IsIn ([<ParamArray>] values : int array) = 
        let createNode value = sprintf "<Value Type='Lookup'>%i</Value>" value
        let formattedValues = 
            values 
            |> Array.map createNode 
            |> System.String.Concat

        LogicalOperatorPicker(                 
            createInNode(fieldDefinition + createValuesNode(formattedValues))
            |> parentBuild                     
        )

and DateFieldFilterPicker(parentBuild : string -> string, fieldDefinition) =        
    member this.IsLessThan (value : System.DateTime) = 
        LogicalOperatorPicker(                 
            parentBuild                     
                <| createLessThanNode(fieldDefinition + (sprintf "<Value IncludeTimeValue='FALSE' Type='DateTime'>%s</Value>" (value.ToString("yyyy-MM-ddTHH:mm:ssZ"))))
        )

    member this.IsNull() =
        LogicalOperatorPicker(                 
            parentBuild                     
                <| createIsNullNode fieldDefinition
        )