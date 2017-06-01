using System;
using System.Collections.Generic;
using System.Text;

namespace Markdown
{
    //TODO Use abstract base class
    public class ListEndLineParserElement : ILineParserElement
    {
        private const string LIST_END_TEXT = "</ul>";

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

