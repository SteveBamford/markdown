using System.Linq;
using Xunit;

namespace Markdown
{
    public class MarkdownLineSplitterTest
    {
        private MarkdownLineSplitter _sut;

        public MarkdownLineSplitterTest()
        {
            _sut = new MarkdownLineSplitter();
        }

        [Fact]
        public void Splits_null_string_into_empty_list()
        {
            var list = _sut.Split(null);
            Assert.Empty(list);
        }

        [Fact]
        public void Splits_single_line_of_text_into_list_with_one_item()
        {
            string input = "Single line of text";
            var list = _sut.Split(input);
            Assert.Single(list);
            Assert.Equal(input, list.ElementAt(0));
        }

        [Fact]
        public void Splits_text_with_multiple_lines_into_list()
        {
            string line1 = "Line1";
            string line2 = "line2";
            string line3 = "line3";
            string input = $"{line1}\n{line2}\n{line3}";
            var list = _sut.Split(input);
            Assert.Equal(3, list.Count());
            Assert.Equal(line1, list.ElementAt(0));
            Assert.Equal(line2, list.ElementAt(1));
            Assert.Equal(line3, list.ElementAt(2));
        }

        [Fact]
        public void Splits_text_with_blank_line_into_list_with_blank_item()
        {
            string input = "Line1\n\nLine3";
            var list = _sut.Split(input);
            Assert.Equal(3, list.Count());
            Assert.Equal("", list.ElementAt(1));
        }
    }
}
