using System;
using System.Collections.Generic;
using System.Text;

namespace Markdown
{
    public interface IParserElement
    {
        ParserResult ParseElement(string markdownLine, bool inListBeforeLine);
    }
}

