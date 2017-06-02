using Xunit;

namespace Markdown
{
    public class ListEndLineParserElementTest
    {
        private const string LIST_END_TEXT = "</ul>";

        private ListEndLineParserElement _sut;

        public ListEndLineParserElementTest()
        {
            _sut = new ListEndLineParserElement();
        }

        [Fact]
        public void Parses_blank_element_to_null_if_not_in_list()
        {
            bool outputInList;
            Assert.Null(_sut.ParseElement("", false, out outputInList));
        }

        [Fact]
        public void Parses_non_blank_element_to_null_if_not_in_list()
        {
            bool outputInList;
            Assert.Null(_sut.ParseElement("some text", false, out outputInList));
        }

        [Fact]
        public void Parses_blank_element_to_list_end_element__if_in_list()
        {
            bool outputInList;
            Assert.Equal(LIST_END_TEXT, _sut.ParseElement("", true, out outputInList));
        }

        [Fact]
        public void Parses_non_blank_element_to_null_if_in_list()
        {
            bool outputInList;
            Assert.Null(_sut.ParseElement("some text", false, out outputInList));
        }
    }
}
