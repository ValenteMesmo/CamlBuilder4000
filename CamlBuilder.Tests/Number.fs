namespace ``Unit tests`` 

module ``Number Filters`` =

    open Xunit
    open ValenteMesmo.CamlQueryBuilder

    [<Fact>]
    let ``Is Equal to`` () =
        let expected ="\
            <View Scope='RecursiveAll'>\
                <Query>\
                    <Where>\
                        <Eq>\
                            <FieldRef Name='campo'/>\
                            <Value Type='Number'>1</Value>\
                        </Eq>\
                    </Where>\
                </Query>\
            </View>"
            
        let actual = 
            CamlBuilder
                .Where(
                    fun f-> f
                                .Number("campo")
                                .IsEqualTo(1)
                )
                .Build()
                            
        Assert.Equal(expected, actual)
