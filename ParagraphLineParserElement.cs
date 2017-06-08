using System;
using System.Collections.Generic;
using System.Text;

namespace Markdown
{
    public class ParagraphLineParserElement : ParserElementTextBase
    {
        public const string PARAGRAPH_TAG_TEXT = "p";

        public override ParserResult ParseElement(string markdownLine, bool inListBeforeLine)
        {
            string parsedLine = markdownLine;

            parsedLine = ParseTextForUnorderedListEndBoldAndItalic(markdownLine, inListBeforeLine);

            if (!inListBeforeLine)
            {
                parsedLine = WrapTextInTag(parsedLine, PARAGRAPH_TAG_TEXT);
            }
            return new ParserResult(parsedLine, false);
        }

    }
}
