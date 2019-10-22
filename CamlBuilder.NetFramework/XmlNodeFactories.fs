namespace ValenteMesmo.Internals.Xml

module internal XmlNodeFactories =

    let createCamlNode nodeName nodeContent = 
        sprintf "<%s>%s</%s>" nodeName nodeContent nodeName 

    let createWhereNode content = 
        createCamlNode "Where" content

    let createAndNode a b =
        createCamlNode "And" (a + b)

    let createOrNode a b =
        createCamlNode "Or" (a + b)

    let createEqualNode content =
        createCamlNode "Eq" content

    let createInNode content =
        createCamlNode "In" content    

    let createLessThanNode content = 
        createCamlNode "Lt" content

    let createIsNullNode content =
        createCamlNode "IsNull" content

    let createValuesNode content =
        createCamlNode "Values" content

    let createTextValueNode content =
        sprintf "<Value Type='Text'><![CDATA[%s]]></Value>" content
