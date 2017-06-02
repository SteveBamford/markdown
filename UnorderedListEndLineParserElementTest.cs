using Xunit;

namespace Markdown
{
    public class UnorderedListEndLineParserElementTest
    {
        private const string LIST_END_TEXT = "</ul>";

        private UnorderedListEndLineParserElement _sut;

        public UnorderedListEndLineParserElementTest()
        {
            _sut = new UnorderedListEndLineParserElement();
        }

        [Fact]
        public void Parses_blank_element_to_element_if_not_in_list()
        {
            Assert.Equal("", _sut.ParseElement("", false).ParsedText);
        }

        [Fact]
        public void Parses_non_blank_element_to_element_if_not_in_list()
        {
            string text = "some text";
            Assert.Equal(text, _sut.ParseElement(text, false).ParsedText);
        }

        [Fact]
        public void Parses_blank_element_to_list_end_element_if_in_list()
        {
            Assert.Equal(LIST_END_TEXT, _sut.ParseElement("", true).ParsedText);
        }

        [Fact]
        public void Parses_non_blank_element_to_element_if_in_list()
        {
            string text = "some text";
            Assert.Equal($"{LIST_END_TEXT}{text}", _sut.ParseElement(text, true).ParsedText);
        }
    }
}
