using System;
using System.Collections.Generic;
using System.Text;

namespace Markdown
{
    public class UnorderedListStartLineParserElement : ILineParserElement
    {
        private const string LIST_START_TEXT = "<ul>";

        public string ParseElement(string markdownLine, bool inListBeforeLine, out bool inListAfterLine)
        {
            inListAfterLine = inListBeforeLine;
            if (!inListBeforeLine)
            {
                return $"{LIST_START_TEXT}{markdownLine}";
            }
            return markdownLine;
        }
    }
}
