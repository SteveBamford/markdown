using System;
using System.Collections.Generic;
using System.Text;

namespace Markdown
{
    public interface IMarkdownLineSplitter
    {
        // this name could be more descriptive I think. eg SplitAtNewlines or something
        IEnumerable<string> Split(string markdownText);
    }
}
