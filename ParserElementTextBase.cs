using System;
using System.Collections.Generic;
using System.Text;

namespace Markdown
{
    public abstract class ParserElementTextBase : ParserElementBase
    {
        private BoldParserElement _boldTextParser;
        private ItalicParserElement _italicTextParser;
        private UnorderedListEndParserElement _unorderedListEndParser;

        public ParserElementTextBase()
        {
            _boldTextParser = new BoldParserElement();
            _italicTextParser = new ItalicParserElement();
            _unorderedListEndParser = new UnorderedListEndParserElement();
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
