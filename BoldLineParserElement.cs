using System;
using System.Collections.Generic;
using System.Text;

namespace Markdown
{
    public class BoldLineParserElement : LineParserElementBase
    {
        private const string BOLD_MARKDOWN_TEXT = "__";
        private const string BOLD_REPLACEMENT_TEXT = "strong";

        public override string ParseElement(string markdownLine, bool inListBeforeLine, out bool inListAfterLine)
        {
            inListAfterLine = inListBeforeLine;
            return Parse(markdownLine, BOLD_MARKDOWN_TEXT, BOLD_REPLACEMENT_TEXT);
        }
    }
}
