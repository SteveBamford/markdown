using Xunit;

namespace Markdown
{
    public class BoldLineParserElementTest
    {
        private const string REPLACEMENT_TAG_TEXT = "strong";

        private BoldLineParserElement _sut;

        public BoldLineParserElementTest()
        {
            _sut = new BoldLineParserElement();
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
