using System;
using System.Collections.Generic;
using System.Text;

namespace Markdown
{
    public class UnorderedListLineParserElement : LineParserElementTextBase
    {
        public const string UNORDERED_LIST_MARKDOWN_TEXT = "*";
        public const string UNORDERED_LIST_LINE_ITEM_TAG_TEXT = "li";

        private UnorderedListStartLineParserElement _startTagger;

        public UnorderedListLineParserElement()
        {
            _startTagger = new UnorderedListStartLineParserElement();
        }

        public override LineParserResult ParseElement(string markdownLine, bool inListBeforeLine)
        {

            if (markdownLine.StartsWith(UNORDERED_LIST_MARKDOWN_TEXT))
            {
                var htmlLine = ParseTextForBoldAndItalic(markdownLine.Substring(2), inListBeforeLine);
                htmlLine = WrapTextInTag(htmlLine, UNORDERED_LIST_LINE_ITEM_TAG_TEXT);
                var result = _startTagger.ParseElement(htmlLine, inListBeforeLine);
                return new LineParserResult(result.ParsedText, true);
            }
            return new LineParserResult(null, inListBeforeLine);
        }
    }
}
