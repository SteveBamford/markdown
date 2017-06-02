using System;
using System.Collections.Generic;
using System.Text;

namespace Markdown
{
    public class UnorderedListLineParserElement : LineParserElementBase
    {
        public const string UNORDERED_LIST_START_TAG = "<ul>";
        public const string UNORDERED_LIST_END_TAG = "</ul>";

        public override string ParseElement(string markdownLine, bool inListBeforeLine, out bool inListAfterLine)
        {
            inListAfterLine = inListBeforeLine;

            if (inListBeforeLine)
            {
                return $"{UNORDERED_LIST_START_TAG}{markdownLine}";
            }
            return markdownLine;
        }
    }
}
