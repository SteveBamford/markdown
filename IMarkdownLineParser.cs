using System;
using System.Collections.Generic;
using System.Text;

namespace Markdown
{
    public interface IMarkdownLineParser
    {
        string ParseLines(IEnumerable<string> markdownLines);
    }
}

