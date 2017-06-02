using System;
using System.Collections.Generic;
using System.Text;

namespace Markdown
{
    public class UnorderedListStartLineParserElement : ILineParserElement
    {
        private const string LIST_START_TEXT = "<ul>";

        public LineParserResult ParseElement(string markdownLine, bool inListBeforeLine)
        {
            if (!inListBeforeLine)
            {
                return new LineParserResult($"{LIST_START_TEXT}{markdownLine}", inListBeforeLine);
            }
            return new LineParserResult(markdownLine, inListBeforeLine);
        }
    }
}
