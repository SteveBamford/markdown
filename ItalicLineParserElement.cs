using System;
using System.Collections.Generic;
using System.Text;

namespace Markdown
{
    public class ItalicLineParserElement : LineParserElementBase
    {
        private const string ITALIC_MARKDOWN_TEXT = "_";
        private const string ITALIC_REPLACEMENT_TEXT = "em";

        public override string ParseElement(string markdownLine, bool inListBeforeLine, out bool inListAfterLine)
        {
            inListAfterLine = inListBeforeLine;
            return Parse(markdownLine, ITALIC_MARKDOWN_TEXT, ITALIC_REPLACEMENT_TEXT);
        }
    }
}
