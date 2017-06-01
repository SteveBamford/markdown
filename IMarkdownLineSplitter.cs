using System;
using System.Collections.Generic;
using System.Text;

namespace Markdown
{
    public interface IMarkdownLineSplitter
    {
        IEnumerable<string> Split(string markdownText);
    }
}
