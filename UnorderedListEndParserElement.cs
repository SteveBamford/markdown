using System;
using System.Collections.Generic;
using System.Text;

namespace Markdown
{
    public class UnorderedListEndParserElement : IParserElement
    {
        private const string LIST_END_TEXT = "</ul>";

        public UnorderedListEndParserElement() : base()
        { }

        public ParserResult ParseElement(string markdownLine, bool inListBeforeLine)
        {
            if (inListBeforeLine)
            {
                return new ParserResult($"{LIST_END_TEXT}{markdownLine}", false);
            }
            return new ParserResult(markdownLine, false);
        }
    }
}

