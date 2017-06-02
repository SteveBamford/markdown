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

        public override string ParseElement(string markdownLine, bool inListBeforeLine, out bool inListAfterLine)
        {

            if (markdownLine.StartsWith(UNORDERED_LIST_MARKDOWN_TEXT))
            {
                
                var result = _startTagger.ParseElement(WrapTextInTag(ParseTextForBoldAndItalic(markdownLine.Substring(2), inListBeforeLine), UNORDERED_LIST_LINE_ITEM_TAG_TEXT), inListBeforeLine, out inListAfterLine);
                inListAfterLine = true;
                return result;
            }
            inListAfterLine = inListBeforeLine;
            return null;
        }
    }
}
