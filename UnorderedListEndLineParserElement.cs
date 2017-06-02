using System;
using System.Collections.Generic;
using System.Text;

namespace Markdown
{
    public class UnorderedListEndLineParserElement : ILineParserElement
    {
        private const string LIST_END_TEXT = "</ul>";

        public UnorderedListEndLineParserElement() : base()
        { }

        public string ParseElement(string markdownLine, bool inListBeforeLine, out bool inListAfterLine)
        {
            inListAfterLine = false;
            if (inListBeforeLine)
            {
                return LIST_END_TEXT;
            }
            return null;
        }
    }
}

