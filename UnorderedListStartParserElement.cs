using System;
using System.Collections.Generic;
using System.Text;

namespace Markdown
{
    public class UnorderedListStartParserElement : IParserElement
    {
        private const string LIST_START_TEXT = "<ul>";

        public ParserResult ParseElement(string markdownLine, bool inListBeforeLine)
        {
            if (!inListBeforeLine)
            {
                return new ParserResult($"{LIST_START_TEXT}{markdownLine}", inListBeforeLine);
            }
            return new ParserResult(markdownLine, inListBeforeLine);
        }
    }
}
