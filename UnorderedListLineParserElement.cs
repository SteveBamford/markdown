using System;
using System.Collections.Generic;
using System.Text;

namespace Markdown
{
    public class UnorderedListLineParserElement : ParserElementTextBase
    {
        public const string UNORDERED_LIST_MARKDOWN_TEXT = "*";
        public const string UNORDERED_LIST_LINE_ITEM_TAG_TEXT = "li";

        private UnorderedListStartParserElement _startTagger;

        public UnorderedListLineParserElement()
        {
            _startTagger = new UnorderedListStartParserElement();
        }

        public override ParserResult ParseElement(string markdownLine, bool inListBeforeLine)
        {

            if (markdownLine.StartsWith(UNORDERED_LIST_MARKDOWN_TEXT))
            {
                var htmlLine = ParseTextForBoldAndItalic(markdownLine.Substring(2), inListBeforeLine);
                htmlLine = WrapTextInTag(htmlLine, UNORDERED_LIST_LINE_ITEM_TAG_TEXT);
                // this adds in the first <UL> I guess? Could probably have a better name. Including the "if inListBeforeLine" statement in this method might make it clearer
                var result = _startTagger.ParseElement(htmlLine, inListBeforeLine);
                return new ParserResult(result.ParsedText, true);
            }
            return new ParserResult(null, inListBeforeLine);
        }
    }
}
