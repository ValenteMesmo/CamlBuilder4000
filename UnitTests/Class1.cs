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
                .TextEqual("a", "1")
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
                .TextEqual("a", "1")
                .And()
                .TextEqual("b", "2")
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
                .TextEqual("a", "1")
                .And()
                .TextEqual("b", "2")
                .And()
                .TextEqual("c", "3")
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
                .TextEqual("a", "1")
                .Or()
                .TextEqual("b", "2")
                .Or()
                .TextEqual("c", "3")
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
                .TextEqual("a", "1")
                .Or()
                .TextEqual("b", "2")
                .And()
                .TextEqual("c", "3")
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
                .TextEqual("a", "1")
                .And()
                .TextEqual("b", "2")
                .And(f => 
                    f.TextEqual("c", "3")
                    .Or()
                    .TextEqual("d", "4"))
                .ToString();

            Assert.Equal(expected, actual);
        }
    }
}
