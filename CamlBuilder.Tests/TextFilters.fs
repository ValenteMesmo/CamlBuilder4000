namespace ``Unit tests`` 

module ``Text Filters`` =

    open Xunit
    open ValenteMesmo.CamlQueryBuilder

    [<Fact>]
    let ``Is Equal to`` () =
        let expected ="\
            <View>\
                <Query>\
                    <Where>\
                        <Eq>\
                            <FieldRef Name='campo'/>\
                            <Value Type='Text'><![CDATA[valor]]></Value>\
                        </Eq>\
                    </Where>\
                </Query>\
            </View>"
            
        let actual = 
            CamlQuery
                .Where(
                    fun f-> f
                                .Text("campo")
                                .IsEqualTo("valor")
                )
                .Build()
                            
        Assert.Equal(expected, actual)

    [<Fact>]
    let ``Is Not Equal to`` () =
        let expected ="\
            <View>\
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
            CamlQuery
                .Where(
                    fun f-> f
                                .Text("campo")
                                .IsNotEqualTo("valor")
                )
                .Build()
                            
        Assert.Equal(expected, actual)