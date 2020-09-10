namespace ``Unit tests`` 

module ``Lookup Filters`` =

    open Xunit
    open ValenteMesmo.CamlQueryBuilder

    [<Fact>]
    let ``Is Equal to`` () =
        let expected ="\
            <View Scope='RecursiveAll'>\
                <Query>\
                    <Where>\
                        <Eq>\
                            <FieldRef Name='campo' LookupId='TRUE'/>\
                            <Value Type='Lookup'>6</Value>\
                        </Eq>\
                    </Where>\
                </Query>\
            </View>"
            
        let actual = 
            CamlBuilder
                .Where(
                    fun f-> f
                                .LookupId("campo")
                                .IsEqualTo(6)
                )
                .Build()
                            
        Assert.Equal(expected, actual)

    [<Fact>]
    let ``Is Not Equal to`` () =
        let expected ="\
            <View Scope='RecursiveAll'>\
                <Query>\
                    <Where>\
                        <Neq>\
                            <FieldRef Name='campo'/>\
                            <Value Type='Text'><![CDATA[valor]]></Value>\
                        </Neq>\
                    </Where>\
                </Query>\
            </View>"
            
        let actual = 
            CamlBuilder
                .Where(
                    fun f-> f
                                .Text("campo")
                                .IsNotEqualTo("valor")
                )
                .Build()
                            
        Assert.Equal(expected, actual)

    [<Fact>]
    let ``Contains`` () =
        let expected ="\
            <View Scope='RecursiveAll'>\
                <Query>\
                    <Where>\
                        <Contains>\
                            <FieldRef Name='Title'/>\
                            <Value Type='Text'><![CDATA[2]]></Value>\
                        </Contains>\
                    </Where>\
                </Query>\
            </View>"
            
        let actual = 
            CamlBuilder
                .Where(
                    fun f-> f
                                .Text("Title")
                                .Contains("2")
                )
                .Build()
                            
        Assert.Equal(expected, actual)