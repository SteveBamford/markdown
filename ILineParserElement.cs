using System;
using System.Collections.Generic;
using System.Text;

namespace Markdown
{
    public interface ILineParserElement
    {
        LineParserResult ParseElement(string markdownLine, bool inListBeforeLine);
    }
}

