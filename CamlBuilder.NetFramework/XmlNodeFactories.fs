namespace ValenteMesmo.CamlQueryBuilder.Internals.Xml

module internal XmlNodeFactories =

    let createCamlNode nodeName nodeContent = 
        sprintf "<%s>%s</%s>" nodeName nodeContent nodeName 

    let createViewNode content = 
        createCamlNode "View" content

    let createQueryNode content = 
        createCamlNode "Query" content

    let createWhereNode content = 
        createCamlNode "Where" content

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

    let createIsNullNode content =
        createCamlNode "IsNull" content

    let createValuesNode content =
        createCamlNode "Values" content

    let createRowLimitNode(content : int) = 
        sprintf "<RowLimit Paged='False'>%i</RowLimit>" content

    let createTextValueNode(content : string) =
        sprintf "<Value Type='Text'><![CDATA[%s]]></Value>" content

    let createLookupValueNode(value : int) =
        sprintf "<Value Type='Lookup'>%i</Value>" value

    let createDateOnlyValue(value : System.DateTime) = 
        sprintf
            <| "<Value IncludeTimeValue='FALSE' Type='DateTime'>%s</Value>" 
            <| value.ToString("yyyy-MM-ddTHH:mm:ssZ")

    let createFieldRef fieldName = 
        sprintf "<FieldRef Name='%s'/>" fieldName

    let createLookupIdFieldRef fieldName = 
         sprintf "<FieldRef Name='%s' LookupId='TRUE'/>" fieldName
