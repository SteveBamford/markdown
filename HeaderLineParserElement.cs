using System;
using System.Collections.Generic;
using System.Text;

namespace Markdown
{
    //todo: in terms of single responsibility, this class also has the responsibility of writing out a closing tag for a different element, so this should be removed.
    public class HeaderLineParserElement : ParserElementBase
    {
        //todo: make this shorter. One control stucture per method is ideal.
        public override ParserResult ParseElement(string markdownLine, bool inListBeforeLine)
        {
            // todo: martin fowler would have you inlining GetHeaderCount everywhere it is used and removing this variable. if markdownline becomes an instance variable as well then it can become a property and just as readable as this, but with less things to think about
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

        // I think some linq can make this more concise. It could probably also be refactored as a while to avoid the break clause. you could probably also return i in a while loop to avoid having the count variable.
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

        // eg like this (not tested)
        static int GetHeaderCountCedd(string markdownLine)
        {
            int character = 0;

            while (IsWithinLine(markdownLine, character) 
                   &&
                   IsHeaderCharacter(character))
                character++;

            return character;
        }

        static bool IsWithinLine(string markdownLine, int character) =>
            character < markdownLine.Length;

        static bool IsHeaderCharacter(int character) =>
            character == '#';
    }
}
