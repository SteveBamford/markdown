using System;
using System.Collections.Generic;
using System.Text;

namespace Markdown
{
    public class ParagraphLineParserElement : LineParserElementTextBase
    {
        public const string PARAGRAPH_TAG_TEXT = "p";

        public override string ParseElement(string markdownLine, bool inListBeforeLine, out bool inListAfterLine)
        {
            string parsedLine = markdownLine;

            inListAfterLine = false;

            parsedLine = ParseTextForUnorderedListEndBoldAndItalic(markdownLine, inListBeforeLine);

            if (!inListBeforeLine)
            {
                parsedLine = WrapTextInTag(parsedLine, PARAGRAPH_TAG_TEXT);
            }
            return parsedLine;
        }

    }
}
