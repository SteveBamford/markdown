using Xunit;


namespace Markdown
{
    public class ItalicLineParserElementTest
    {
        private ItalicLineParserElement _sut;
        
        public ItalicLineParserElementTest()
        {
            _sut = new ItalicLineParserElement();
        }

        [Fact]
        public void Parses_single_underscore_to_same_text()
        {
            bool inListAfter = true;

            Assert.Equal("_", _sut.ParseElement("_", false, out inListAfter));
        }

        [Fact]
        public void Parses_text_surrounded_by_underscores_to_text_surrounded_by_em()
        {
            bool inListAfter = true;
            string text = "some text";

            Assert.Equal($"<em>{text}</em>", _sut.ParseElement($"_{text}_", false, out inListAfter));
        }
    }
}
