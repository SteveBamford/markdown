using Xunit;

namespace Markdown
{
    public class UnorderedListLineParserElementTest
    {

        private UnorderedListLineParserElement _sut;

        public UnorderedListLineParserElementTest()
        {
            _sut = new UnorderedListLineParserElement();
        }

        // these are good tests that describe what the code is expected to do.
        [Fact]
        public void Parse_unordered_list_item_not_in_list_before_starts_with_ul_tag()
        {
            string lineText = "List";
            string markdownLine = $"* {lineText}";
            string expectedText = $"<ul><li>{lineText}</li>";
            // maybe have an IsInList variable instead of passing false, its a key part of the test
            Assert.Equal(expectedText, _sut.ParseElement(markdownLine, false).ParsedText);
        }

        [Fact]
        public void Parse_unordered_list_item_in_list_before_does_not_start_with_ul_tag()
        {
            string lineText = "List";
            string markdownLine = $"* {lineText}";
            string expectedText = $"<li>{lineText}</li>";
            Assert.Equal(expectedText, _sut.ParseElement(markdownLine, true).ParsedText);
        }
    }
}
