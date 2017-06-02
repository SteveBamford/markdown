using Xunit;

namespace Markdown
{
    public class UnorderedListStartLineParserElementTest
    {
        private const string LIST_START_TEXT = "<ul>";
        private UnorderedListStartLineParserElement _sut;

        public UnorderedListStartLineParserElementTest()
        {
            _sut = new UnorderedListStartLineParserElement();
        }

        [Fact]
        public void Parse_not_in_list_adds_start_tag_before_text()
        {
            bool inListBefore = false;
            string lineText = "some line";
            string expectedText = $"{LIST_START_TEXT}{lineText}";
            Assert.Equal(expectedText, _sut.ParseElement(lineText, inListBefore).ParsedText);
        }

        [Fact]
        public void Parse_in_list_does_not_add_start_tag_before_text()
        {
            bool inListBefore = true;
            string lineText = "some line";
            string expectedText = lineText;
            Assert.Equal(expectedText, _sut.ParseElement(lineText, inListBefore).ParsedText);
        }
    }
}
