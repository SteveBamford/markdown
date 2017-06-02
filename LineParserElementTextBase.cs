using System;
using System.Collections.Generic;
using System.Text;

namespace Markdown
{
    public abstract class LineParserElementTextBase : LineParserElementBase
    {
        private BoldLineParserElement _boldTextParser;
        private ItalicLineParserElement _italicTextParser;
        private UnorderedListEndLineParserElement _unorderedListEndParser;

        public LineParserElementTextBase()
        {
            _boldTextParser = new BoldLineParserElement();
            _italicTextParser = new ItalicLineParserElement();
            _unorderedListEndParser = new UnorderedListEndLineParserElement();
        }

        protected string ParseTextForUnorderedListEndBoldAndItalic(string markdownText, bool inListBefore)
        {
            return ParseTextForBoldAndItalic(
                _unorderedListEndParser.ParseElement(
                    markdownText,
                    inListBefore).ParsedText, 
                inListBefore);
        }

        protected string ParseTextForBoldAndItalic(string markdownText, bool inListBefore)
        {
            return _italicTextParser.ParseElement(
                    _boldTextParser.ParseElement(
                        markdownText,
                        false).ParsedText,
                    false).ParsedText;
        }

    }
}
