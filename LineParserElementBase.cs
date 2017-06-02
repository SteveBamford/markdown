using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Markdown
{
    public abstract class LineParserElementBase : ILineParserElement
    {
        protected ILineParserElement _listEndParserElement;

        public LineParserElementBase() : this(new UnorderedListEndLineParserElement())
        {
        }

        public LineParserElementBase(ILineParserElement listEndParserElement)
        {
            _listEndParserElement = listEndParserElement;
        }

        public abstract string ParseElement(string markdownLine, bool inListBeforeLine, out bool inListAfterLine);

        protected string WrapTextInTag(string text, string tag)
        {
            return $"<{tag}>{text}</{tag}>";
        }

        protected string Parse(string markdownText, string delimiter, string tag)
        {
            var pattern = $"{delimiter}(.+){delimiter}";
            var replacement = $"<{tag}>$1</{tag}>";
            return Regex.Replace(markdownText, pattern, replacement);
        }
    }
}
