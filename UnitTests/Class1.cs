using CamlBuilder4000;
using Xunit;

namespace UnitTests
{
    public class Class1
    {
        [Fact]
        public void EmptyQuery()
        {
            var actual = CamlBuilder.Start().ToString();

            Assert.Equal("", actual);
        }

        [Fact]
        public void SingleCondition()
        {
            var expected = "<Where>" +
                    "<Eq>" +
                        "<FieldRef Name=\"a\" />" +
                        "<Value Type=\"Text\">1</Value>" +
                    "</Eq>" +
                "</Where>";

            var actual = CamlBuilder.Start()
                .Text("a").Equal("1")
                .ToString();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TwoConditions()
        {
            var expected = "<Where>" +
                    "<And>" +
                        "<Eq>" +
                            "<FieldRef Name=\"a\" />" +
                            "<Value Type=\"Text\">1</Value>" +
                        "</Eq>" +
                        "<Eq>" +
                            "<FieldRef Name=\"b\" />" +
                            "<Value Type=\"Text\">2</Value>" +
                        "</Eq>" +
                    "</And>" +
                "</Where>";

            var actual = CamlBuilder.Start()
                .Text("a")
                .Equal("1")
                .And()
                .Text("b")
                .Equal("2")
                .ToString();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ComplexOne()
        {
            var expected = "<Where>"
               + "<And>"
                  + "<In>"
                    + "<FieldRef Name=\"Area\" LookupId=\"TRUE\" />"
                     + "<Values>"
                       + "<Value Type=\"Lookup\">1</Value>"
                        + "<Value Type=\"Lookup\">2</Value>"
                        + "<Value Type=\"Lookup\">3</Value>"
                     + "</Values>"
                  + "</In>"
                 + "<Or>"
                     + "<Or>"
                        + "<Or>"
                          + "<Or>"
                              + "<Or>"
                                 + "<Eq>"
                                   + "<FieldRef Name=\"Status\" />"
                                    + "<Value Type=\"Text\">1</Value>"
                                 + "</Eq>"
                                 + "<Eq>"
                                    + "<FieldRef Name=\"Status\" />"
                                    + "<Value Type=\"Text\">2</Value>"
                                 + "</Eq>"
                              + "</Or>"
                              + "<Eq>"
                                 + "<FieldRef Name=\"Status\" />"
                                 + "<Value Type=\"Text\">3</Value>"
                              + "</Eq>"
                           + "</Or>"
                           + "<Eq>"
                              + "<FieldRef Name=\"Status\" />"
                              + "<Value Type=\"Text\">4</Value>"
                           + "</Eq>"
                        + "</Or>"
                        + "<Eq>"
                           + "<FieldRef Name=\"Status\" />"
                           + "<Value Type=\"Text\">5</Value>"
                        + "</Eq>"
                     + "</Or>"
                     + "<Eq>"
                        + "<FieldRef Name=\"Status\" />"
                        + "<Value Type=\"Text\">6</Value>"
                     + "</Eq>"
                  + "</Or>"
               + "</And>"
            + "</Where>";

            var actual = CamlBuilder.Start()
                .LookupId("Area").In(1, 2, 3)
                .And(q => q
                    .Text("Status").Equal("1")
                    .Or()
                    .Text("Status").Equal("2")
                    .Or()
                    .Text("Status").Equal("3")
                    .Or()
                    .Text("Status").Equal("4")
                    .Or()
                    .Text("Status").Equal("5")
                    .Or()
                    .Text("Status").Equal("6"))
                .ToString();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ComplexOneWithOr()
        {
            var expected = "<Where>"
               + "<Or>"
                  + "<In>"
                    + "<FieldRef Name=\"Area\" LookupId=\"TRUE\" />"
                     + "<Values>"
                       + "<Value Type=\"Lookup\">1</Value>"
                        + "<Value Type=\"Lookup\">2</Value>"
                        + "<Value Type=\"Lookup\">3</Value>"
                     + "</Values>"
                  + "</In>"
                 + "<And>"
                     + "<And>"
                        + "<And>"
                          + "<And>"
                              + "<And>"
                                 + "<Eq>"
                                   + "<FieldRef Name=\"Status\" />"
                                    + "<Value Type=\"Text\">1</Value>"
                                 + "</Eq>"
                                 + "<Eq>"
                                    + "<FieldRef Name=\"Status\" />"
                                    + "<Value Type=\"Text\">2</Value>"
                                 + "</Eq>"
                              + "</And>"
                              + "<Eq>"
                                 + "<FieldRef Name=\"Status\" />"
                                 + "<Value Type=\"Text\">3</Value>"
                              + "</Eq>"
                           + "</And>"
                           + "<Eq>"
                              + "<FieldRef Name=\"Status\" />"
                              + "<Value Type=\"Text\">4</Value>"
                           + "</Eq>"
                        + "</And>"
                        + "<Eq>"
                           + "<FieldRef Name=\"Status\" />"
                           + "<Value Type=\"Text\">5</Value>"
                        + "</Eq>"
                     + "</And>"
                     + "<Eq>"
                        + "<FieldRef Name=\"Status\" />"
                        + "<Value Type=\"Text\">6</Value>"
                     + "</Eq>"
                  + "</And>"
               + "</Or>"
            + "</Where>";

            var actual = CamlBuilder.Start()
                .LookupId("Area").In(1, 2, 3)
                .Or(q => q
                    .Text("Status").Equal("1")
                    .And()
                    .Text("Status").Equal("2")
                    .And()
                    .Text("Status").Equal("3")
                    .And()
                    .Text("Status").Equal("4")
                    .And()
                    .Text("Status").Equal("5")
                    .And()
                    .Text("Status").Equal("6"))
                .ToString();

            Assert.Equal(expected, actual);
        }


        [Fact]
        public void ThreeConditions()
        {
            var expected = "<Where>" +
                    "<And>" +
                        "<And>" +
                            "<Eq>" +
                                "<FieldRef Name=\"a\" />" +
                                "<Value Type=\"Text\">1</Value>" +
                            "</Eq>" +
                            "<Eq>" +
                                "<FieldRef Name=\"b\" />" +
                                "<Value Type=\"Text\">2</Value>" +
                            "</Eq>" +
                        "</And>" +
                        "<Eq>" +
                            "<FieldRef Name=\"c\" />" +
                            "<Value Type=\"Text\">3</Value>" +
                        "</Eq>" +
                    "</And>" +
                "</Where>";

            var actual = CamlBuilder.Start()
                .Text("a").Equal("1")
                .And()
                .Text("b").Equal("2")
                .And()
                .Text("c").Equal("3")
                .ToString();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ThreeConditionsWithOrs()
        {
            var expected = "<Where>" +
                    "<Or>" +
                        "<Or>" +
                            "<Eq>" +
                                "<FieldRef Name=\"a\" />" +
                                "<Value Type=\"Text\">1</Value>" +
                            "</Eq>" +
                            "<Eq>" +
                                "<FieldRef Name=\"b\" />" +
                                "<Value Type=\"Text\">2</Value>" +
                            "</Eq>" +
                        "</Or>" +
                        "<Eq>" +
                            "<FieldRef Name=\"c\" />" +
                            "<Value Type=\"Text\">3</Value>" +
                        "</Eq>" +
                    "</Or>" +
                "</Where>";

            var actual = CamlBuilder.Start()
                .Text("a").Equal("1")
                .Or()
                .Text("b").Equal("2")
                .Or()
                .Text("c").Equal("3")
                .ToString();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ThreeConditionsWithOrsAndAnds()
        {
            var expected = "<Where>" +
                    "<And>" +
                        "<Or>" +
                            "<Eq>" +
                                "<FieldRef Name=\"a\" />" +
                                "<Value Type=\"Text\">1</Value>" +
                            "</Eq>" +
                            "<Eq>" +
                                "<FieldRef Name=\"b\" />" +
                                "<Value Type=\"Text\">2</Value>" +
                            "</Eq>" +
                        "</Or>" +
                        "<Eq>" +
                            "<FieldRef Name=\"c\" />" +
                            "<Value Type=\"Text\">3</Value>" +
                        "</Eq>" +
                    "</And>" +
                "</Where>";

            var actual = CamlBuilder.Start()
                .Text("a").Equal("1")
                .Or()
                .Text("b").Equal("2")
                .And()
                .Text("c").Equal("3")
                .ToString();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void NestedConditions()
        {
            var expected = "<Where>" +
                    "<And>" +
                        "<And>" +
                            "<Eq>" +
                                "<FieldRef Name=\"a\" />" +
                                "<Value Type=\"Text\">1</Value>" +
                            "</Eq>" +
                            "<Eq>" +
                                "<FieldRef Name=\"b\" />" +
                                "<Value Type=\"Text\">2</Value>" +
                            "</Eq>" +
                        "</And>" +
                        "<Or>" +
                            "<Eq>" +
                                "<FieldRef Name=\"c\" />" +
                                "<Value Type=\"Text\">3</Value>" +
                            "</Eq>" +
                            "<Eq>" +
                                "<FieldRef Name=\"d\" />" +
                                "<Value Type=\"Text\">4</Value>" +
                            "</Eq>" +
                        "</Or>" +
                    "</And>" +
                "</Where>";

            var actual = CamlBuilder.Start()
                .Text("a").Equal("1")
                .And()
                .Text("b").Equal("2")
                .And(f => f
                    .Text("c").Equal("3")
                    .Or()
                    .Text("d").Equal("4"))
                .ToString();

            Assert.Equal(expected, actual);
        }
    }
}
