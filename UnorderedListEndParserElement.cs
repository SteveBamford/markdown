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

        // it is clear what this does, which is good, but it is a bit unclear how it should be used. It seems like a special case that would be used in a different way to other IParserElements.
        public ParserResult ParseElement(string markdownLine, bool inListBeforeLine)
        {
            // use ternary operator
            if (inListBeforeLine)
            {
                return new ParserResult($"{LIST_END_TEXT}{markdownLine}", false);
            }
            return new ParserResult(markdownLine, false);
        }
    }
}

