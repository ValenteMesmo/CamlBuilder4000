namespace ValenteMesmo.CamlQueryBuilder.Internals.Xml

module internal XmlNodeFactories =

    let concat a b =
        sprintf "%s%s" a b

    let createCamlNode nodeName nodeContent = 
        sprintf "<%s>%s</%s>" nodeName nodeContent nodeName 

    let createViewNode content = 
        sprintf "<View Scope='RecursiveAll'>%s</View>" content

    let createQueryNode content = 
        createCamlNode "Query" content

    let createWhereNode content = 
        createCamlNode "Where" content

    let createOrderByNode fieldname =
        sprintf "<OrderBy>\
                    <FieldRef Name='%s' Ascending='TRUE' />\
                </OrderBy>" fieldname

    let createOrderByDescNode fieldname =
        sprintf "<OrderBy>\
                    <FieldRef Name='%s' Ascending='False' />\
                </OrderBy>" fieldname

    let createAndNode a b =
        createCamlNode "And" (a + b)

    let createOrNode a b =
        createCamlNode "Or" (a + b)

    let createEqualNode content =
        createCamlNode "Eq" content

    let createNotEqualNode content =
        createCamlNode "Neq" content

    let createContainsNode content =
        createCamlNode "Contains" content

    let createInNode content =
        createCamlNode "In" content    

    let createLessThanNode content = 
        createCamlNode "Lt" content

    let createGreaterThanNode content = 
        createCamlNode "Gt" content        

    let createIsNullNode content =
        createCamlNode "IsNull" content

    let createIsNotNullNode content =
        createCamlNode "IsNotNull" content

    let createValuesNode content =
        createCamlNode "Values" content

    let createRowLimitNode(content : int) = 
        sprintf "<RowLimit>%i</RowLimit>" content

    let createTextValueNode(content : string) =
        sprintf "<Value Type='Text'><![CDATA[%s]]></Value>" content

    let createIntValueNode(content: int) =
        sprintf "<Value Type='Number'>%i</Value>" content

    let createFloatValueNode(content: float) =
        sprintf "<Value Type='Number'>%f</Value>" content

    let createDecimalValueNode(content: decimal) =
        sprintf "<Value Type='Number'>%f</Value>" content

    let createPathValueNode(content : string) =
        sprintf "<Value Type='Text'>%s</Value>" content

    let createLookupIntValueNode(value : int) =
        sprintf "<Value Type='Lookup'>%i</Value>" value

    let createLookupGuidValueNode(value : System.Guid) =
        sprintf "<Value Type='Lookup'>%A</Value>" value

    let createLookupStringValueNode(value : string) =
        sprintf "<Value Type='Lookup'>%s</Value>" value

    let createBoolValueNode(value: bool) =
        if(value) then
            "<Value Type='Boolean'>1</Value>"
        else
            "<Value Type='Boolean'>0</Value>"

    let createDateOnlyValue(value : System.DateTime) = 
        sprintf
            <| "<Value IncludeTimeValue='FALSE' Type='DateTime'>%s</Value>" 
            <| value.ToString("yyyy-MM-ddTHH:mm:ssZ")

    let createFieldRef fieldName = 
        sprintf "<FieldRef Name='%s'/>" fieldName

    let createLookupIdFieldRef fieldName = 
         sprintf "<FieldRef Name='%s' LookupId='TRUE'/>" fieldName
