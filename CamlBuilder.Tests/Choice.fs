namespace ``Unit tests`` 

module ``Choice Filters`` =

    open Xunit
    open ValenteMesmo.CamlQueryBuilder
    open System

    [<Fact>]
    let ``Is Equal to`` () =
        let expected ="\
            <View Scope='RecursiveAll'>\
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
            CamlBuilder
                .Where(
                    fun f-> f
                                .Choice("campo")
                                .IsEqualTo("valor")
                )
                .Build()
                            
        Assert.Equal(expected, actual)