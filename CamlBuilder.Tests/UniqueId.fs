namespace ``Unit tests`` 

module ``UniqueId Filters`` =

    open Xunit
    open ValenteMesmo.CamlQueryBuilder

    [<Fact>]
    let ``Is Equal to Guid`` () =
        let expected ="\
            <View Scope='RecursiveAll'>\
                <Query>\
                    <Where>\
                        <Eq>\
                            <FieldRef Name='UniqueId'/>\
                            <Value Type='Lookup'>00000000-0000-0000-0000-000000000000</Value>\
                        </Eq>\
                    </Where>\
                </Query>\
            </View>"
            
        let actual = 
            CamlBuilder
                .Where(
                    fun f-> f
                                .UniqueId()
                                .IsEqualTo(System.Guid.Empty)
                )
                .Build()
                            
        Assert.Equal(expected, actual)

    [<Fact>]
    let ``Is Equal to String`` () =
        let expected ="\
            <View Scope='RecursiveAll'>\
                <Query>\
                    <Where>\
                        <Eq>\
                            <FieldRef Name='UniqueId'/>\
                            <Value Type='Lookup'>00000000-0000-0000-0000-000000000000</Value>\
                        </Eq>\
                    </Where>\
                </Query>\
            </View>"
            
        let actual = 
            CamlBuilder
                .Where(
                    fun f-> f
                                .UniqueId()
                                .IsEqualTo(System.Guid.Empty.ToString())
                )
                .Build()
                            
        Assert.Equal(expected, actual)