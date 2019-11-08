namespace ``Unit tests`` 

module ``FileDirRef Filters`` =

    open Xunit
    open ValenteMesmo.CamlQueryBuilder

    [<Fact>]
    let ``Is Equal to`` () =
        let expected ="\
            <View Scope='RecursiveAll'>\
                <Query>\
                    <Where>\
                        <Eq>\
                            <FieldRef Name='FileDirRef'/>\
                            <Value Type='Text'>/folder/subFolder</Value>\
                        </Eq>\
                    </Where>\
                </Query>\
            </View>"
            
        let actual = 
            CamlQuery
                .Where(
                    fun f-> f
                                .FileDirRef()
                                .IsEqualTo("/folder/subFolder")
                )
                .Build()
                            
        Assert.Equal(expected, actual)