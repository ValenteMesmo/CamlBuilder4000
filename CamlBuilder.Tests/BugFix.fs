namespace ``Unit tests`` 

module ``Bug fix`` =

    open Xunit
    open ValenteMesmo.CamlQueryBuilder

    [<Fact>]
    let ``Pru`` () =
        let expected ="\
            <View Scope='RecursiveAll'>\
                <Query>\
                    <Where>\
                        <And>\
                            <And>\
                                <Eq>\
                                    <FieldRef Name='Area' LookupId='TRUE'/>\
                                    <Value Type='Lookup'>1</Value>\
                                </Eq>\
                                <Eq>\
                                    <FieldRef Name='EmailAlertaEnviado'/>\
                                    <Value Type='Boolean'>0</Value>\
                                </Eq>\
                            </And>\
                            <Or>\
                                <Or>\
                                    <Or>\
                                        <Or>\
                                            <Or>\
                                                <Or>\
                                                    <Or>\
                                                        <Or>\
                                                            <Or>\
                                                                <Eq>\
                                                                    <FieldRef Name='Status'/>\
                                                                    <Value Type='Text'>\
                                                                        <![CDATA[Pendência em DPI]]>\
                                                                    </Value>\
                                                                </Eq>\
                                                                <Eq>\
                                                                    <FieldRef Name='Status'/>\
                                                                    <Value Type='Text'>\
                                                                        <![CDATA[Pendência na Aplicação de Marca]]>\
                                                                    </Value>\
                                                                </Eq>\
                                                            </Or>\
                                                            <Eq>\
                                                                <FieldRef Name='Status'/>\
                                                                <Value Type='Text'>\
                                                                    <![CDATA[Pendência Jurídica]]>\
                                                                </Value>\
                                                            </Eq>\
                                                        </Or>\
                                                        <Eq>\
                                                            <FieldRef Name='Status'/>\
                                                            <Value Type='Text'>\
                                                                <![CDATA[Pendência em Compliance]]>\
                                                            </Value>\
                                                        </Eq>\
                                                    </Or>\
                                                    <Eq>\
                                                        <FieldRef Name='Status'/>\
                                                        <Value Type='Text'>\
                                                            <![CDATA[Pendência na Revisão de Texto]]>\
                                                        </Value>\
                                                    </Eq>\
                                                </Or>\
                                                <Eq>\
                                                    <FieldRef Name='Status'/>\
                                                    <Value Type='Text'>\
                                                        <![CDATA[Análise das Alterações do(s) Aprovador(es)]]>\
                                                    </Value>\
                                                </Eq>\
                                            </Or>\
                                            <Eq>\
                                                <FieldRef Name='Status'/>\
                                                <Value Type='Text'>\
                                                    <![CDATA[Pendência na Produção]]>\
                                                </Value>\
                                            </Eq>\
                                        </Or>\
                                        <Eq>\
                                            <FieldRef Name='Status'/>\
                                            <Value Type='Text'>\
                                                <![CDATA[Aprovação da Programação Visual]]>\
                                            </Value>\
                                        </Eq>\
                                    </Or>\
                                    <Eq>\
                                        <FieldRef Name='Status'/>\
                                        <Value Type='Text'>\
                                            <![CDATA[Aprovação do Documento]]>\
                                        </Value>\
                                    </Eq>\
                                </Or>\
                                <Eq>\
                                    <FieldRef Name='Status'/>\
                                    <Value Type='Text'>\
                                        <![CDATA[Pendência na Publicação]]>\
                                    </Value>\
                                </Eq>\
                            </Or>\
                        </And>\
                    </Where>\
                </Query>\
                <RowLimit>100</RowLimit>\
            </View>"

        let actual = 
            CamlBuilder
                .Where(
                    fun f-> f
                                .LookupId("Area").IsEqualTo(1)
                                .And()
                                .Bool("EmailAlertaEnviado").IsFalse()
                                .And(fun f -> 
                                    f.Text("Status").IsEqualTo("Pendência em DPI")
                                        .Or()
                                        .Text("Status").IsEqualTo("Pendência na Aplicação de Marca")
                                        .Or()
                                        .Text("Status").IsEqualTo("Pendência Jurídica")
                                        .Or()
                                        .Text("Status").IsEqualTo("Pendência em Compliance")
                                        .Or()
                                        .Text("Status").IsEqualTo("Pendência na Revisão de Texto")
                                        .Or()
                                        .Text("Status").IsEqualTo("Análise das Alterações do(s) Aprovador(es)")
                                        .Or()
                                        .Text("Status").IsEqualTo("Pendência na Produção")
                                        .Or()
                                        .Text("Status").IsEqualTo("Aprovação da Programação Visual")
                                        .Or()
                                        .Text("Status").IsEqualTo("Aprovação do Documento")
                                        .Or()
                                        .Text("Status").IsEqualTo("Pendência na Publicação"))
                )
                .RowLimit(100)
                .Build()
                            
        Assert.Equal(expected, actual)

    [<Fact>]
    let ``Fixing rowlimit and adding orderby`` () =
        let expected = "\
            <View Scope='RecursiveAll'>\
                <Query>\
                    <OrderBy>\
                        <FieldRef Name='ID' Ascending='False' />\
                    </OrderBy>\
                </Query>\
            <RowLimit>1000</RowLimit>\
            </View>"
        let actual = 
            CamlBuilder
                        .OrderByDesc("ID")
                        .RowLimit(1000)
                        .Build();
        Assert.Equal(expected, actual)

    [<Fact>]
    let ``Orderby`` () =
        let expected = "\
            <View Scope='RecursiveAll'>\
                <Query>\
                    <Where>\
                        <Eq>\
                            <FieldRef Name='Status'/>\
                            <Value Type='Text'>\
                                <![CDATA[Ready]]>\
                            </Value>\
                        </Eq>\
                    </Where>\
                    <OrderBy>\
                        <FieldRef Name='ID' Ascending='TRUE' />\
                    </OrderBy>\
                </Query>\
                <RowLimit>1000</RowLimit>\
            </View>"
        let actual = 
            CamlBuilder
                        .Where(fun f -> f.Text("Status").IsEqualTo("Ready"))
                        .OrderBy("ID")
                        .RowLimit(1000)
                        .Build();
        Assert.Equal(expected, actual)

    [<Fact>]
    let ``RowLimit after where`` () =
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
                <RowLimit>100</RowLimit>\
            </View>"

        let actual = 
            CamlBuilder
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
            "<View Scope='RecursiveAll'>\
                <Query>\
                    <Where>\
                        <And>\
                            <Eq>\
                                <FieldRef Name='Status'/>\
                                <Value Type='Text'><![CDATA[Aprovação do Documento]]></Value>\
                            </Eq>\
                            <And>\
                                <Eq>\
                                    <FieldRef Name='Area' LookupId='TRUE'/>\
                                    <Value Type='Lookup'>1</Value>\
                                </Eq>\
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

        let actual = CamlBuilder
                        .Where(fun f -> f
                                            .Text("Status")
                                            .IsEqualTo("Aprovação do Documento")
                                            .And(fun g -> g
                                                            .LookupIdMulti("Area")
                                                            .Contains(1)
                                                            .And(fun h -> h
                                                                            .Date("UltimoAlertaDePrazo")
                                                                            .IsLessThan(System.DateTime(1989, 04, 08))
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
            "<View Scope='RecursiveAll'>\
                <Query>\
                    <Where>\
                        <And>\
                            <Eq>\
                                <FieldRef Name='Area' LookupId='TRUE'/>\
                                <Value Type='Lookup'>2</Value>\
                            </Eq>\
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

        let actual = CamlBuilder
                        .Where(fun f-> f
                                        .LookupIdMulti("Area").Contains(2)
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
