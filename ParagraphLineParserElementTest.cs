using Xunit;

namespace Markdown
{
    public class ParagraphLineParserElementTest
    {
        private const string PARAGRAPH_START_TAG = "<p>";
        private const string PARAGRAPH_END_TAG = "</p>";
        private const string UNORDERED_LIST_START_TAG = "<ul>";
        private const string UNORDERED_LIST_END_TAG = "</ul>";

        private ParagraphLineParserElement _sut;

        public ParagraphLineParserElementTest()
        {
            _sut = new ParagraphLineParserElement();
        }

        [Fact]
        public void Parse_simple_line_to_simple_line_in_paragraph_tags()
        {
            bool inListBefore = false;
            string simpleLine = "She sells sea shells on the sea shore.";
            string expectedResult = $"{PARAGRAPH_START_TAG}{simpleLine}{PARAGRAPH_END_TAG}";
            var result = _sut.ParseElement(simpleLine, inListBefore);
            Assert.Equal(expectedResult, result.ParsedText);
            Assert.False(result.InList);
        }

        [Fact]
        public void Parse_simple_line_in_list_to_simple_line_starting_with_list_end_tag()
        {
            bool inListBefore = true;
            string simpleLine = "She sells sea shells on the sea shore.";
            string expectedResult = $"{UNORDERED_LIST_END_TAG}{simpleLine}";
            var result = _sut.ParseElement(simpleLine, inListBefore);
            Assert.Equal(expectedResult, result.ParsedText);
            Assert.False(result.InList);
        }

        [Fact]
        public void Parse_line_with_bold_and_italic_to_line_in_paragraph_tags_with_bold_and_italic_tags()
        {
            bool inListBefore = false;
            string inputLine = "She _sells_ __sea shells__ on the sea shore.";
            string inputLineWithBoldAndItalicTags = "She <em>sells</em> <strong>sea shells</strong> on the sea shore.";
            string expectedResult = $"{PARAGRAPH_START_TAG}{inputLineWithBoldAndItalicTags}{PARAGRAPH_END_TAG}";
            var result = _sut.ParseElement(inputLine, inListBefore);
            Assert.Equal(expectedResult, result.ParsedText);
            Assert.False(result.InList);
        }


    }
}
