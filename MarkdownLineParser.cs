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
            string lineResult = null;
            foreach (var line in markdownLines)
            {
                foreach (var parserElement in _lineParserElements)
                {
                    lineResult = parserElement.ParseElement(line, inList, out inList);
                    if (lineResult != null)
                    {
                        break;
                    }
                }
                if (lineResult.Equals(line))
                    throw new ArgumentException("Invalid markdown");
                result += lineResult;
            }

            result += _listEndParserElement.ParseElement("", inList, out inList);
            return result;

        }

        private static IEnumerable<ILineParserElement> DefaultLineParserElements
        {
            get
            {
                return new List<ILineParserElement> { new HeaderLineParserElement(), new UnorderedListLineParserElement(), new ParagraphLineParserElement() };
            }
        }

    }
}
