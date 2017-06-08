using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Markdown
{
    public abstract class ParserElementBase : IParserElement
    {
        protected IParserElement _listEndParserElement;

        public ParserElementBase() : this(new UnorderedListEndParserElement())
        {
        }

        public ParserElementBase(IParserElement listEndParserElement)
        {
            _listEndParserElement = listEndParserElement;
        }

        public abstract ParserResult ParseElement(string markdownLine, bool inListBeforeLine);

        protected string WrapTextInTag(string text, string tag)
        {
            return $"<{tag}>{text}</{tag}>";
        }

        protected string Parse(string markdownText, string delimiter, string tag)
        {
            if (markdownText == null || markdownText.Length == 0)
                return markdownText;
            var pattern = $"{delimiter}(.+){delimiter}";
            var replacement = $"<{tag}>$1</{tag}>";
            return Regex.Replace(markdownText, pattern, replacement);
        }
    }
}
