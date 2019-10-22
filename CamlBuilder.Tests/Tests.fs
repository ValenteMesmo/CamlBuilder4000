namespace ``Um nome qualquer`` 

module ``agora sim`` =

    open Xunit
    open ValenteMesmo.CamlQueryBuilder

    [<Fact>]
    let ``RowLimit after where`` () =
        let sut = CamlQuery.Where(fun f-> f
                                                .Text("campo")
                                                .IsEqualTo("valor"))
                            .RowLimit(100)
                            .Build()
                            
        Assert.Equal("\
                <View>\
                    <Where>\
                        <Eq>\
                            <FieldRef Name='campo'/>\
                            <Value Type='Text'><![CDATA[valor]]></Value>\
                        </Eq>\
                    </Where>\
                    <RowLimit Paged='False'>100</RowLimit>\
                </View>", sut)

    [<Fact>]
    let ``1 filter test`` () =
        let sut = CamlQuery.Where(fun f-> f
                                                .Text("campo")
                                                .IsEqualTo("valor"))
                            .Build()
                            
        Assert.Equal("\
                <View>\
                    <Where>\
                        <Eq>\
                            <FieldRef Name='campo'/>\
                            <Value Type='Text'><![CDATA[valor]]></Value>\
                        </Eq>\
                    </Where>\
                </View>", sut)

    [<Fact>]
    let ``2 filters test (and)`` () =
        let sut = CamlQuery
                    .Where(fun f-> f
                                    .Text("campo")
                                    .IsEqualTo("valor")
                                    .And()
                                    .Text("campo2")
                                    .IsEqualTo("valor2")
                    )
                    .Build()

        Assert.Equal("\
            <View>\
                <Where>\
                    <And>\
                        <Eq>\
                            <FieldRef Name='campo'/>\
                            <Value Type='Text'><![CDATA[valor]]></Value>\
                        </Eq>\
                        <Eq>\
                            <FieldRef Name='campo2'/>\
                            <Value Type='Text'><![CDATA[valor2]]></Value>\
                        </Eq>\
                    </And>\
                </Where>\
            </View>", sut)

    [<Fact>]
    let ``2 filters test (or)`` () =
        let sut = CamlQuery
                    .Where(fun f-> f
                                    .Text("campo")
                                    .IsEqualTo("valor")
                                    .Or()
                                    .Text("campo2")
                                    .IsEqualTo("valor2")
                    )
                    .Build()

        Assert.Equal("\
            <View>\
                <Where>\
                    <Or>\
                        <Eq>\
                            <FieldRef Name='campo'/>\
                            <Value Type='Text'><![CDATA[valor]]></Value>\
                        </Eq>\
                        <Eq>\
                            <FieldRef Name='campo2'/>\
                            <Value Type='Text'><![CDATA[valor2]]></Value>\
                        </Eq>\
                    </Or>\
                </Where>\
            </View>", sut)

    [<Fact>]
    let ``bug fix``() =
        let expeceted = 
            "<View>\
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
    let ``3 filter test``() =
        let expected = 
            "<View>\
                <Where>\
                    <And>\
                        <And>\
                            <Eq>\
                                <FieldRef Name='a'/>\
                                <Value Type='Text'><![CDATA[1]]></Value>\
                            </Eq>\
                            <Eq>\
                                <FieldRef Name='b'/>\
                                <Value Type='Text'><![CDATA[2]]></Value>\
                            </Eq>\
                        </And>\
                        <Eq>\
                            <FieldRef Name='c'/>\
                            <Value Type='Text'><![CDATA[3]]></Value>\
                        </Eq>\
                    </And>\
                </Where>\
            </View>"

        let actual = CamlQuery
                        .Where(fun f-> f
                                        .Text("a").IsEqualTo("1")
                                        .And()
                                        .Text("b").IsEqualTo("2")
                                        .And()
                                        .Text("c").IsEqualTo("3")
                        )
                        .Build();

        Assert.Equal(expected, actual);

    [<Fact>]
    let ``Complex one``() =
        let expected =
            "<View>\
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
