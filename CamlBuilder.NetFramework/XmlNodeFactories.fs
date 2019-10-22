module XmlNodeFactories 

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
