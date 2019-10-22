namespace ``Um nome qualquer`` 

module ``agora sim`` =

    open Xunit
    open CamlBuilder.NetFramework
    

    [<Fact>]
    let ``1 filter test`` () =
        let sut = CamlBuilder.Where(fun f-> f
                                                .Text("campo")
                                                .IsEqualTo("valor"))
                            .Build

        Assert.Equal("<Where>\
                        <Eq>\
                            <FieldRef Name='campo'/>\
                            <Value Type='Text'><![CDATA[valor]]></Value>\
                        </Eq>\
                      </Where>", sut)

    [<Fact>]
    let ``2 filters test (and)`` () =
        let sut = CamlBuilder
                    .Where(fun f-> f
                                    .Text("campo")
                                    .IsEqualTo("valor")
                                    .And()
                                    .Text("campo2")
                                    .IsEqualTo("valor2")
                    )
                    .Build

        Assert.Equal("<Where>\
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
                      </Where>", sut)

    [<Fact>]
    let ``2 filters test (or)`` () =
        let sut = CamlBuilder
                    .Where(fun f-> f
                                    .Text("campo")
                                    .IsEqualTo("valor")
                                    .Or()
                                    .Text("campo2")
                                    .IsEqualTo("valor2")
                    )
                    .Build

        Assert.Equal("<Where>\
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
                      </Where>", sut)

    [<Fact>]
    let ``bug fix``() =
        let expeceted = 
            "<Where>\
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
            </Where>"

        let actual = CamlBuilder
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
                        .Build;

        Assert.Equal(expeceted, actual);

    [<Fact>]
    let ``3 filter test``() =
        let expected = 
            "<Where>\
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
            </Where>"

        let actual = CamlBuilder
                        .Where(fun f-> f
                                        .Text("a").IsEqualTo("1")
                                        .And()
                                        .Text("b").IsEqualTo("2")
                                        .And()
                                        .Text("c").IsEqualTo("3")
                        )
                        .Build;

        Assert.Equal(expected, actual);

    [<Fact>]
    let ``Complex one``() =
        let expected =
            "<Where>\
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
            </Where>"

        let actual = CamlBuilder
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
                                        ).Build

        Assert.Equal(expected, actual)
