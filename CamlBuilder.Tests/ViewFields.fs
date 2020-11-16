namespace ``Unit tests`` 

module ``ViewFields`` =

    open Xunit
    open ValenteMesmo.CamlQueryBuilder

    [<Fact>]
    let ``Example`` () =
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
                <ViewFields>\
                    <FieldRef Name='Title'/>\
                    <FieldRef Name='Id'/>\
                </ViewFields>\
                <RowLimit>1000</RowLimit>\
            </View>"
            
        let actual = 
            CamlBuilder
                .Where(
                    fun f-> f
                                .Choice("campo")
                                .IsEqualTo("valor")
                )
                .ViewFields("Title", "Id")
                .RowLimit(1000)
                .Build()
                            
        Assert.Equal(expected, actual)