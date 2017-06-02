using System;
using System.Collections.Generic;
using System.Text;

namespace Markdown
{
    public class MarkdownLineParser : IMarkdownLineParser
    {
        private IEnumerable<ILineParserElement> _lineParserElements;
        private ILineParserElement _listEndParserElement;

        public MarkdownLineParser() : this(DefaultLineParserElements, new UnorderedListEndLineParserElement())
        {

        }

        public MarkdownLineParser(IEnumerable<ILineParserElement> lineParserElements, ILineParserElement listEndParserElement)
        {
            _lineParserElements = lineParserElements;
            _listEndParserElement = listEndParserElement;
        }

        public string ParseLines(IEnumerable<string> markdownLines)
        {
            string result = null;
            bool inList = false;
            foreach (var line in markdownLines)
            {
                result += MarkdownStaticToBeRemoved.ParseLine(line, inList, out inList);
                //foreach (var parserElement in _lineParserElements)
                //{
                //    result += parserElement.ParseElement(line, inList, out inList);
                //}
            }
            result += _listEndParserElement.ParseElement("", inList, out inList);
            return result;

        }

        private static IEnumerable<ILineParserElement> DefaultLineParserElements
        {
            get
            {
                return new List<ILineParserElement> { new UnorderedListEndLineParserElement(), new HeaderLineParserElement(), new UnorderedListLineParserElement(), new ParagraphLineParserElement() };
            }
        }

    }
}
