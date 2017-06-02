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
            
            foreach (var markdownLine in markdownLines)
            {
                LineParserResult lineResult = GetLineParserResult(inList, markdownLine);
                result += lineResult.ParsedText;
                inList = lineResult.InList;
            }

            result += _listEndParserElement.ParseElement("", inList).ParsedText;
            return result;

        }

        private LineParserResult GetLineParserResult(bool inListBeforeLine, string markdownLineText)
        {
            LineParserResult lineResult = null;
            foreach (var parserElement in _lineParserElements)
            {
                lineResult = parserElement.ParseElement(markdownLineText, inListBeforeLine);
                if (lineResult.ParsedText != null)
                {
                    break;
                }
            }
            ConsiderExceptionConditions(markdownLineText, lineResult);

            return lineResult;
        }

        private static void ConsiderExceptionConditions(string markdownLineText, LineParserResult lineResult)
        {
            if (lineResult == null)
            {
                throw new ArgumentException("No line parser elements run.");
            }
            else if (lineResult.ParsedText.Equals(markdownLineText))
            {
                throw new ArgumentException("Invalid markdown");
            }
        }

        private static IEnumerable<ILineParserElement> DefaultLineParserElements
        {
            get
            {
                return new List<ILineParserElement> {
                    new HeaderLineParserElement(),
                    new UnorderedListLineParserElement(),
                    new ParagraphLineParserElement()
                };
            }
        }

    }
}
