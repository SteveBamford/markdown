using Xunit;

// this is picky, but I might put the tests in their own namespace
namespace Markdown
{
    public class HeaderLineParserElementTest
    {
        private HeaderLineParserElement _sut;

        public HeaderLineParserElementTest()
        {
            _sut = new HeaderLineParserElement();
        }

        // looks good, I would probably put some blank lines to separate the various sections
        [Fact]
        public void Parse_top_level_header_line()
        {
            string headerText = "Header 1";
            string markdownH1Line = $"# {headerText}";
            string htmlH1Line = $"<h1>{headerText}</h1>";

            var result = _sut.ParseElement(markdownH1Line, false);

            Assert.Equal(htmlH1Line, result.ParsedText);
            Assert.False(result.InList);
        }


        [Fact]
        public void Parse_lower_level_header_line()
        {
            string headerText = "Header 3";
            string markdownLine = $"### {headerText}";
            string htmlLine = $"<h3>{headerText}</h3>";
            var result = _sut.ParseElement(markdownLine, false);
            Assert.Equal(htmlLine, result.ParsedText);
            Assert.False(result.InList);
        }
    }
}
