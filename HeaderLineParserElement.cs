using System;
using System.Collections.Generic;
using System.Text;

namespace Markdown
{
    public class HeaderLineParserElement : LineParserElementBase
    {
        public override string ParseElement(string markdownLine, bool inListBeforeLine, out bool inListAfterLine)
        {
            int headerCount = GetHeaderCount(markdownLine);

            if (headerCount == 0)
            {
                inListAfterLine = inListBeforeLine;
                return null;
            }

            var headerTag = "h" + headerCount;
            var headerHtml = WrapTextInTag(markdownLine.Substring(headerCount + 1), headerTag);

            if (inListBeforeLine)
            {
                inListAfterLine = false;
                return _listEndParserElement.ParseElement("", true, out inListAfterLine) + headerHtml;
            }
            else
            {
                inListAfterLine = false;
                return headerHtml;
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
