using System;
using System.Collections.Generic;
using System.Text;

namespace Markdown
{
    public class ListEndLineParserElement : LineParserElementBase
    {
        private const string LIST_END_TEXT = "</ul>";

        public override string ParseElement(string markdownLine, bool inListBeforeLine, out bool inListAfterLine)
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

