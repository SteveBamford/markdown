using System;
using System.Collections.Generic;
using System.Text;

namespace Markdown
{
    public class UnorderedListEndLineParserElement : ILineParserElement
    {
        private const string LIST_END_TEXT = "</ul>";

        public UnorderedListEndLineParserElement() : base()
        { }

        public LineParserResult ParseElement(string markdownLine, bool inListBeforeLine)
        {
            if (inListBeforeLine)
            {
                return new LineParserResult($"{LIST_END_TEXT}{markdownLine}", false);
            }
            return new LineParserResult(markdownLine, false);
        }
    }
}

