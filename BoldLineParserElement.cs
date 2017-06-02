using System;
using System.Collections.Generic;
using System.Text;

namespace Markdown
{
    public class BoldLineParserElement : LineParserElementBase
    {
        private const string BOLD_MARKDOWN_TEXT = "__";
        private const string BOLD_REPLACEMENT_TEXT = "strong";

        public override LineParserResult ParseElement(string markdownLine, bool inListBeforeLine)
        {
            return new LineParserResult(Parse(markdownLine, BOLD_MARKDOWN_TEXT, BOLD_REPLACEMENT_TEXT), inListBeforeLine);
        }
    }
}
