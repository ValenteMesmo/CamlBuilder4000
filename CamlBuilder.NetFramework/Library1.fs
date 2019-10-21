namespace CamlBuilder.NetFramework

open System

//where builder
//orderby
//viewfields
//row limit
//groupby

//CAML query to check if user is member of a specific group
//  using Membership 

module CamlBuilderInternals =

    let internal createCamlNode nodeName nodeContent = 
        sprintf "<%s>%s</%s>" nodeName nodeContent nodeName 

    let internal createWhereNode content = 
        createCamlNode "Where" content

    let internal createAndNode a b =
        createCamlNode "And" (a + b)

    let internal createOrNode a b =
        createCamlNode "Or" (a + b)

    let internal createEqualNode content =
        createCamlNode "Eq" content

    let internal createInNode content =
        createCamlNode "In" content    

    let internal createLessThanNode content = 
        createCamlNode "Lt" content

    let internal createIsNullNode content =
        createCamlNode "IsNull" content

    let internal createValuesNode content =
        createCamlNode "Values" content

    let internal createTextValueNode content =
        sprintf "<Value Type='Text'><![CDATA[%s]]></Value>" content

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

    and FieldTypePicker(parentBuild : string -> string) =
        member this.Build =
            parentBuild

        member this.Text fieldName = 
            new TextFieldFilterPicker(parentBuild, sprintf "<FieldRef Name='%s'/>" fieldName) 

        member this.LookupId fieldName = 
            new LookupIdFieldFilterPicker(parentBuild, sprintf "<FieldRef Name='%s' LookupId='TRUE'/>" fieldName) 

        member this.Date fieldName = 
            new DateFieldFilterPicker(parentBuild, sprintf "<FieldRef Name='%s'/>" fieldName) 

    type WhereBuilder(handler : FieldTypePicker -> LogicalOperatorPicker) =        
        let whereContent = handler(new FieldTypePicker(fun f -> f))
        member this.Build = createWhereNode <| whereContent.Build
        //member this.OrderBy fieldName = ""

[<AbstractClass; Sealed>]
type CamlBuilder private () =
    static member Where handler =
        new CamlBuilderInternals.WhereBuilder(handler)