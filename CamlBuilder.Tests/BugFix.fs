namespace ``Unit tests`` 

module ``Bug fix`` =

    open Xunit
    open ValenteMesmo.CamlQueryBuilder

    [<Fact>]
    let ``RowLimit after where`` () =
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
                <RowLimit Paged='False'>100</RowLimit>\
            </View>"

        let actual = 
            CamlQuery
                .Where(
                    fun f-> f
                                .Text("campo")
                                .IsEqualTo("valor")
                )
                .RowLimit(100)
                .Build()
                            
        Assert.Equal(expected, actual)

    [<Fact>]
    let ``bug fix``() =
        let expeceted = 
            "<View>\
                <Query>\
                    <Where>\
                        <And>\
                            <Eq>\
                                <FieldRef Name='Status'/>\
                                <Value Type='Text'><![CDATA[Aprovação do Documento]]></Value>\
                            </Eq>\
                            <And>\
                                <In>\
                                    <FieldRef Name='Area' LookupId='TRUE'/>\
                                    <Values>\
                                        <Value Type='Lookup'>1</Value>\
                                    </Values>\
                                </In>\
                                <Or>\
                                    <Lt>\
                                        <FieldRef Name='UltimoAlertaDePrazo'/>\
                                        <Value IncludeTimeValue='FALSE' Type='DateTime'>\
                                            1989-04-08T00:00:00Z\
                                        </Value>\
                                    </Lt>\
                                    <IsNull>\
                                        <FieldRef Name='UltimoAlertaDePrazo'/>\
                                    </IsNull>\
                                </Or>\
                            </And>\
                        </And>\
                    </Where>\
                </Query>\
            </View>"

        let actual = CamlQuery
                        .Where(fun f -> f
                                            .Text("Status")
                                            .IsEqualTo("Aprovação do Documento")
                                            .And(fun g -> g
                                                            .LookupId("Area")
                                                            .IsIn(1)
                                                            .And(fun h -> h
                                                                            .Date("UltimoAlertaDePrazo")
                                                                            .IsLessThan(new System.DateTime(1989, 04, 08))
                                                                            .Or()
                                                                            .Date("UltimoAlertaDePrazo")
                                                                            .IsNull()
                                                            )
                                            )               
                        )        
                        .Build();

        Assert.Equal(expeceted, actual);

    [<Fact>]
    let ``Complex one``() =
        let expected =
            "<View>\
                <Query>\
                    <Where>\
                        <And>\
                            <In>\
                                <FieldRef Name='Area' LookupId='TRUE'/>\
                                <Values>\
                                    <Value Type='Lookup'>1</Value>\
                                    <Value Type='Lookup'>2</Value>\
                                    <Value Type='Lookup'>3</Value>\
                                </Values>\
                            </In>\
                            <Or>\
                                <Or>\
                                    <Or>\
                                    <Or>\
                                        <Or>\
                                            <Eq>\
                                            <FieldRef Name='Status'/>\
                                                <Value Type='Text'><![CDATA[1]]></Value>\
                                            </Eq>\
                                            <Eq>\
                                                <FieldRef Name='Status'/>\
                                                <Value Type='Text'><![CDATA[2]]></Value>\
                                            </Eq>\
                                        </Or>\
                                        <Eq>\
                                            <FieldRef Name='Status'/>\
                                            <Value Type='Text'><![CDATA[3]]></Value>\
                                        </Eq>\
                                    </Or>\
                                    <Eq>\
                                        <FieldRef Name='Status'/>\
                                        <Value Type='Text'><![CDATA[4]]></Value>\
                                    </Eq>\
                                    </Or>\
                                    <Eq>\
                                    <FieldRef Name='Status'/>\
                                    <Value Type='Text'><![CDATA[5]]></Value>\
                                    </Eq>\
                                </Or>\
                                <Eq>\
                                    <FieldRef Name='Status'/>\
                                    <Value Type='Text'><![CDATA[6]]></Value>\
                                </Eq>\
                            </Or>\
                        </And>\
                    </Where>\
                </Query>\
            </View>"

        let actual = CamlQuery
                        .Where(fun f-> f
                                        .LookupId("Area").IsIn(1, 2, 3)
                                        .And(fun q -> q
                                                        .Text("Status").IsEqualTo("1")
                                                        .Or()
                                                        .Text("Status").IsEqualTo("2")
                                                        .Or()
                                                        .Text("Status").IsEqualTo("3")
                                                        .Or()
                                                        .Text("Status").IsEqualTo("4")
                                                        .Or()
                                                        .Text("Status").IsEqualTo("5")
                                                        .Or()
                                                        .Text("Status").IsEqualTo("6"))
                                        ).Build()

        Assert.Equal(expected, actual)
