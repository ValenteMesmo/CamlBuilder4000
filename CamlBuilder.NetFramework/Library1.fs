namespace CamlBuilder.NetFramework

open System
open File1
//where builder
//orderby
//viewfields
//row limit
//groupby

//CAML query to check if user is member of a specific group
//  using Membership 

open XmlNodeFactories

module CamlBuilderInternals =

    type FieldTypePicker with
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

    type WhereBuilder(handler : FieldTypePicker -> LogicalOperatorPicker) =        
        let whereContent = handler(new FieldTypePicker(fun f -> f))
        member this.Build = createWhereNode <| whereContent.Build
        //member this.OrderBy fieldName = ""

[<AbstractClass; Sealed>]
type CamlBuilder private () =
    static member Where handler =
        new CamlBuilderInternals.WhereBuilder(handler)