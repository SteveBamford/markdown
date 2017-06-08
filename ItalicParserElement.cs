using System;
using System.Collections.Generic;
using System.Text;

namespace Markdown
{
    public class ItalicParserElement : ParserElementBase
    {
        private const string ITALIC_MARKDOWN_TEXT = "_";
        private const string ITALIC_REPLACEMENT_TEXT = "em";

        public override ParserResult ParseElement(string markdownLine, bool inListBeforeLine)
        {
            return new ParserResult(
                Parse(markdownLine, ITALIC_MARKDOWN_TEXT, ITALIC_REPLACEMENT_TEXT),
                inListBeforeLine);
        }
    }
}
