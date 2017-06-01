using System;
using System.Collections.Generic;
using System.Text;

namespace Markdown
{
    public interface ILineParserElement
    {
        string ParseElement(string markdownLine, bool inListBeforeLine, out bool inListAfterLine);
    }
}

