namespace ``Unit tests`` 

module ``Logical conditions`` =

    open Xunit
    open ValenteMesmo.CamlQueryBuilder

    [<Fact>]
    let ``times 0``() =
        let expected = "\
            <View>\
                <Query>\
                    <Where>\
                        <Eq>\
                            <FieldRef Name='campo0'/>\
                            <Value Type='Text'><![CDATA[valor0]]></Value>\
                        </Eq>\
                    </Where>\
                </Query>\
            </View>"

        let actual = 
            CamlQuery
                .Where(fun f-> f
                                .Text("campo0")
                                .IsEqualTo("valor0")
                )                                
                .Build()

        Assert.Equal(expected, actual)

    [<Fact>]
    let ``times 1``() =
        let expected = "\
            <View>\
                <Query>\
                    <Where>\
                        <And>\
                            <Eq>\
                                <FieldRef Name='campo0'/>\
                                <Value Type='Text'><![CDATA[valor0]]></Value>\
                            </Eq>\
                            <Eq>\
                                <FieldRef Name='campo1'/>\
                                <Value Type='Text'><![CDATA[valor1]]></Value>\
                            </Eq>\
                        </And>\
                    </Where>\
                </Query>\
            </View>"

        let actual = 
            CamlQuery
                .Where(fun f-> f
                                .Text("campo0")
                                .IsEqualTo("valor0")
                                .And()
                                .Text("campo1")
                                .IsEqualTo("valor1")
                )                                
                .Build()

        Assert.Equal(expected, actual)

    [<Fact>]
    let ``times 2``() =
        let expected = "\
            <View>\
                <Query>\
                    <Where>\
                        <And>\
                            <And>\
                                <Eq>\
                                    <FieldRef Name='campo0'/>\
                                    <Value Type='Text'><![CDATA[valor0]]></Value>\
                                </Eq>\
                                <Eq>\
                                    <FieldRef Name='campo1'/>\
                                    <Value Type='Text'><![CDATA[valor1]]></Value>\
                                </Eq>\
                            </And>\
                            <Eq>\
                                <FieldRef Name='campo2'/>\
                                <Value Type='Text'><![CDATA[valor2]]></Value>\
                            </Eq>\
                        </And>\
                    </Where>\
                </Query>\
            </View>"

        let actual = 
            CamlQuery
                .Where(fun f-> f
                                .Text("campo0")
                                .IsEqualTo("valor0")
                                .And()
                                .Text("campo1")
                                .IsEqualTo("valor1")
                                .And()
                                .Text("campo2")
                                .IsEqualTo("valor2")
                )                                
                .Build()

        Assert.Equal(expected, actual)

    [<Fact>]
    let ``times 3``() =
        let expected = "\
            <View>\
                <Query>\
                    <Where>\
                        <Or>\
                            <Or>\
                                <Or>\
                                    <Eq>\
                                        <FieldRef Name='campo0'/>\
                                        <Value Type='Text'><![CDATA[valor0]]></Value>\
                                    </Eq>\
                                    <Eq>\
                                        <FieldRef Name='campo1'/>\
                                        <Value Type='Text'><![CDATA[valor1]]></Value>\
                                    </Eq>\
                                </Or>\
                                <Eq>\
                                    <FieldRef Name='campo2'/>\
                                    <Value Type='Text'><![CDATA[valor2]]></Value>\
                                </Eq>\
                            </Or>\
                            <Eq>\
                                <FieldRef Name='campo3'/>\
                                <Value Type='Text'><![CDATA[valor3]]></Value>\
                            </Eq>\
                        </Or>\
                    </Where>\
                </Query>\
            </View>"

        let actual = 
            CamlQuery
                .Where(fun f-> f
                                .Text("campo0")
                                .IsEqualTo("valor0")
                                .Or()
                                .Text("campo1")
                                .IsEqualTo("valor1")
                                .Or()
                                .Text("campo2")
                                .IsEqualTo("valor2")
                                .Or()
                                .Text("campo3")
                                .IsEqualTo("valor3")
                )                                
                .Build()

        Assert.Equal(expected, actual)

    [<Fact>]
    let ``times 4``() =
        let expected = "\
            <View>\
                <Query>\
                    <Where>\
                        <Or>\
                            <Or>\
                                <Or>\
                                    <Or>\
                                        <Eq>\
                                            <FieldRef Name='campo0'/>\
                                            <Value Type='Text'><![CDATA[valor0]]></Value>\
                                        </Eq>\
                                        <Eq>\
                                            <FieldRef Name='campo1'/>\
                                            <Value Type='Text'><![CDATA[valor1]]></Value>\
                                        </Eq>\
                                    </Or>\
                                    <Eq>\
                                        <FieldRef Name='campo2'/>\
                                        <Value Type='Text'><![CDATA[valor2]]></Value>\
                                    </Eq>\
                                </Or>\
                                <Eq>\
                                    <FieldRef Name='campo3'/>\
                                    <Value Type='Text'><![CDATA[valor3]]></Value>\
                                </Eq>\
                            </Or>\
                            <Eq>\
                                <FieldRef Name='campo4'/>\
                                <Value Type='Text'><![CDATA[valor4]]></Value>\
                            </Eq>\
                        </Or>\
                    </Where>\
                </Query>\
            </View>"

        let actual = 
            CamlQuery
                .Where(fun f-> f
                                .Text("campo0")
                                .IsEqualTo("valor0")
                                .Or()
                                .Text("campo1")
                                .IsEqualTo("valor1")
                                .Or()
                                .Text("campo2")
                                .IsEqualTo("valor2")
                                .Or()
                                .Text("campo3")
                                .IsEqualTo("valor3")
                                .Or()
                                .Text("campo4")
                                .IsEqualTo("valor4")
                )                                
                .Build()

        Assert.Equal(expected, actual)

    [<Fact>]
    let ``times 5``() =
        let expected = "\
            <View>\
                <Query>\
                    <Where>\
                        <Or>\
                            <Or>\
                                <Or>\
                                    <Or>\
                                        <Or>\
                                            <Eq>\
                                                <FieldRef Name='campo0'/>\
                                                <Value Type='Text'><![CDATA[valor0]]></Value>\
                                            </Eq>\
                                            <Eq>\
                                                <FieldRef Name='campo1'/>\
                                                <Value Type='Text'><![CDATA[valor1]]></Value>\
                                            </Eq>\
                                        </Or>\
                                        <Eq>\
                                            <FieldRef Name='campo2'/>\
                                            <Value Type='Text'><![CDATA[valor2]]></Value>\
                                        </Eq>\
                                    </Or>\
                                    <Eq>\
                                        <FieldRef Name='campo3'/>\
                                        <Value Type='Text'><![CDATA[valor3]]></Value>\
                                    </Eq>\
                                </Or>\
                                <Eq>\
                                    <FieldRef Name='campo4'/>\
                                    <Value Type='Text'><![CDATA[valor4]]></Value>\
                                </Eq>\
                            </Or>\
                            <Eq>\
                                <FieldRef Name='campo5'/>\
                                <Value Type='Text'><![CDATA[valor5]]></Value>\
                            </Eq>\
                        </Or>\
                    </Where>\
                </Query>\
            </View>"

        let actual = 
            CamlQuery
                .Where(fun f-> f
                                .Text("campo0")
                                .IsEqualTo("valor0")
                                .Or()
                                .Text("campo1")
                                .IsEqualTo("valor1")
                                .Or()
                                .Text("campo2")
                                .IsEqualTo("valor2")
                                .Or()
                                .Text("campo3")
                                .IsEqualTo("valor3")
                                .Or()
                                .Text("campo4")
                                .IsEqualTo("valor4")
                                .Or()
                                .Text("campo5")
                                .IsEqualTo("valor5")
                )                                
                .Build()

        Assert.Equal(expected, actual)