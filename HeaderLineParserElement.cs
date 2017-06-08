using System;
using System.Collections.Generic;
using System.Text;

namespace Markdown
{
    public class HeaderLineParserElement : ParserElementBase
    {
        public override ParserResult ParseElement(string markdownLine, bool inListBeforeLine)
        {
            int headerCount = GetHeaderCount(markdownLine);

            if (headerCount == 0)
            {
                return new ParserResult(null, inListBeforeLine);
            }

            var headerTag = "h" + headerCount;
            var headerHtml = WrapTextInTag(markdownLine.Substring(headerCount + 1), headerTag);

            if (inListBeforeLine)
            {
                return new ParserResult(_listEndParserElement.ParseElement("", true).ParsedText + headerHtml, false);
            }
            else
            {
                return new ParserResult(headerHtml, false);
            }
        }

        private static int GetHeaderCount(string markdownLine)
        {
            var count = 0;

            for (int i = 0; i < markdownLine.Length; i++)
            {
                if (markdownLine[i] == '#')
                {
                    count += 1;
                }
                else
                {
                    break;
                }
            }

            return count;
        }
    }
}
