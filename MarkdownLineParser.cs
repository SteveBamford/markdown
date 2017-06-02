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
            LineParserResult lineResult = null;
            foreach (var line in markdownLines)
            {
                foreach (var parserElement in _lineParserElements)
                {
                    lineResult = parserElement.ParseElement(line, inList);
                    if (lineResult.ParsedText != null)
                    {
                        inList = lineResult.InList;
                        break;
                    }
                }
                if (lineResult == null)
                {
                    throw new ArgumentException("No line parser elements run.");
                }
                else if (lineResult.ParsedText.Equals(line))
                {
                    throw new ArgumentException("Invalid markdown");
                }
                result += lineResult.ParsedText;
            }

            result += _listEndParserElement.ParseElement("", inList).ParsedText;
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
