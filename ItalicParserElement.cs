using System;
using System.Collections.Generic;
using System.Text;

namespace Markdown
{
    public class ItalicParserElement : ParserElementBase
    {
        private const string ITALIC_MARKDOWN_TEXT = "_";
        private const string ITALIC_REPLACEMENT_TEXT = "em";

        // this doesn't really do anything, and its a bit hard to work out how it relates to the output. Possibly a level of abstraction / redirection too far?
        public override ParserResult ParseElement(string markdownLine, bool inListBeforeLine)
        {
            return new ParserResult(
                Parse(markdownLine, ITALIC_MARKDOWN_TEXT, ITALIC_REPLACEMENT_TEXT),
                inListBeforeLine);
        }
    }
}
