using Xunit;

namespace Markdown
{
    // nice
    public class BoldParserElementTest
    {
        private const string REPLACEMENT_TAG_TEXT = "strong";

        // making things readonly makes them easier to understand / reason about. Not a biggy though, especially in a small test class
        private readonly BoldParserElement _sut;

        public BoldParserElementTest()
        {
            _sut = new BoldParserElement();
        }

        [Fact]
        public void Parses_double_underscore_to_same_text()
        {
            Assert.Equal("__", _sut.ParseElement("__", false).ParsedText);
        }

        [Fact]
        public void Parses_text_surrounded_by_double_underscores_to_text_surrounded_by_strong_tag()
        {
            string text = "some text";

            Assert.Equal($"<{REPLACEMENT_TAG_TEXT}>{text}</{REPLACEMENT_TAG_TEXT}>", _sut.ParseElement($"__{text}__", false).ParsedText);
        }
    }
}
