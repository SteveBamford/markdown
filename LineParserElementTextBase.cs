using System;
using System.Collections.Generic;
using System.Text;

namespace Markdown
{
    public abstract class LineParserElementTextBase : LineParserElementBase
    {
        private BoldLineParserElement _boldTextParser;
        private ItalicLineParserElement _italicTextParser;
        private UnorderedListStartLineParserElement _unorderedListStartParser;

        public LineParserElementTextBase()
        {
            _boldTextParser = new BoldLineParserElement();
            _italicTextParser = new ItalicLineParserElement();
            _unorderedListStartParser = new UnorderedListStartLineParserElement();
        }

        protected string ParseTextForUnorderedListEndBoldAndItalic(string markdownText, bool inListBefore)
        {
            bool inListAfter;
            return _italicTextParser.ParseElement(
                    _boldTextParser.ParseElement(
                            _unorderedListStartParser.ParseElement(
                                markdownText,
                                inListBefore,
                                out inListAfter),
                            false, 
                            out inListAfter), 
                    false, 
                    out inListAfter);
        }

    }
}
