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

        [Fact]
        public void Parse_unordered_list_item_not_in_list_before_starts_with_ul_tag()
        {
            bool inListAfter;
            string lineText = "List";
            string markdownLine = $"* {lineText}";
            string expectedText = $"<ul><li>{lineText}</li>";
            Assert.Equal(expectedText, _sut.ParseElement(markdownLine, false, out inListAfter));
        }

        [Fact]
        public void Parse_unordered_list_item_in_list_before_does_not_start_with_ul_tag()
        {
            bool inListAfter;
            string lineText = "List";
            string markdownLine = $"* {lineText}";
            string expectedText = $"<li>{lineText}</li>";
            Assert.Equal(expectedText, _sut.ParseElement(markdownLine, true, out inListAfter));
        }
    }
}
