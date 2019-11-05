namespace ``Unit tests`` 

module ``Date Filters`` =

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
                            <Value IncludeTimeValue='FALSE' Type='DateTime'>2010-10-10T00:00:00Z</Value>\
                        </Eq>\
                    </Where>\
                </Query>\
            </View>"
            
        let actual = 
            CamlQuery
                .Where(
                    fun f-> f
                                .Date("campo")
                                .IsEqualTo(DateTime(2010,10,10))
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
                            <Value IncludeTimeValue='FALSE' Type='DateTime'>2010-10-10T00:00:00Z</Value>\
                        </Neq>\
                    </Where>\
                </Query>\
            </View>"
            
        let actual = 
            CamlQuery
                .Where(
                    fun f-> f
                                .Date("campo")
                                .IsNotEqualTo(DateTime(2010,10,10))
                )
                .Build()
                            
        Assert.Equal(expected, actual)