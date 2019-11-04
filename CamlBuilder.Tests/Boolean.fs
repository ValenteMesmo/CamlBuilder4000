namespace ``Unit tests`` 

module ``Bool Filters`` =

    open Xunit
    open ValenteMesmo.CamlQueryBuilder
    open System

    [<Fact>]
    let ``Is Equal to true`` () =
        let expected ="\
            <View>\
                <Query>\
                    <Where>\
                        <Eq>\
                            <FieldRef Name='campo'/>\
                            <Value Type='Boolean'>1</Value>\
                        </Eq>\
                    </Where>\
                </Query>\
            </View>"
            
        let actual = 
            CamlQuery
                .Where(
                    fun f-> f
                                .Bool("campo")
                                .IsEqualTo(true)
                )
                .Build()
                            
        Assert.Equal(expected, actual)


    [<Fact>]
    let ``Is Equal to false`` () =
        let expected ="\
            <View>\
                <Query>\
                    <Where>\
                        <Eq>\
                            <FieldRef Name='campo'/>\
                            <Value Type='Boolean'>0</Value>\
                        </Eq>\
                    </Where>\
                </Query>\
            </View>"
            
        let actual = 
            CamlQuery
                .Where(
                    fun f-> f
                                .Bool("campo")
                                .IsEqualTo(false)
                )
                .Build()
                            
        Assert.Equal(expected, actual)