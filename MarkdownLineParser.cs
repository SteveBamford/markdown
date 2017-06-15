using System;
using System.Collections.Generic;
using System.Text;

namespace Markdown
{
    public class MarkdownLineParser : IMarkdownLineParser
    {
        // make readonly
        private IEnumerable<IParserElement> _lineParserElements;
        private IParserElement _listEndParserElement;

        public MarkdownLineParser() : this(DefaultLineParserElements, new UnorderedListEndParserElement())
        {

        }

        public MarkdownLineParser(IEnumerable<IParserElement> lineParserElements, IParserElement listEndParserElement)
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
                // use var
                var lineResult = GetLineParserResult(inList, markdownLine);
                // is this a bug, looks like it would be null?
                result += lineResult.ParsedText;
                inList = lineResult.InList;
            }

            result += _listEndParserElement.ParseElement("", inList).ParsedText;
            return result;

        }

        private ParserResult GetLineParserResult(bool inListBeforeLine, string markdownLineText)
        {
            ParserResult lineResult = null;
            foreach (var parserElement in _lineParserElements)
            {
                // a canParse / DoParse pattern would make this more readable
                lineResult = parserElement.ParseElement(markdownLineText, inListBeforeLine);
                if (lineResult.ParsedText != null)
                {
                    break;
                }
            }
            ConsiderExceptionConditions(markdownLineText, lineResult);

            return lineResult;
        }

        private static void ConsiderExceptionConditions(string markdownLineText, ParserResult lineResult)
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

        // maybe have a different interface for line parsers and other types of parser
        private static IEnumerable<IParserElement> DefaultLineParserElements
        {
            get
            {
                return new List<IParserElement> {
                    new HeaderLineParserElement(),
                    new UnorderedListLineParserElement(),
                    new ParagraphLineParserElement()
                };
            }
        }

    }
}
