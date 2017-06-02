using Xunit;

namespace Markdown
{
    public class HeaderLineParserElementTest
    {

        private HeaderLineParserElement _sut;

        public HeaderLineParserElementTest()
        {
            _sut = new HeaderLineParserElement();
        }

        [Fact]
        public void Parse_top_level_header_line()
        {
            bool inListAfter;
            string headerText = "Header 1";
            string markdownLine = $"# {headerText}";
            string htmlLine = $"<h1>{headerText}</h1>";
            Assert.Equal(htmlLine, _sut.ParseElement(markdownLine, false, out inListAfter));
            Assert.False(inListAfter);
        }


        [Fact]
        public void Parse_lower_level_header_line()
        {
            bool inListAfter;
            string headerText = "Header 3";
            string markdownLine = $"### {headerText}";
            string htmlLine = $"<h3>{headerText}</h3>";
            Assert.Equal(htmlLine, _sut.ParseElement(markdownLine, false, out inListAfter));
            Assert.False(inListAfter);
        }
    }
}
