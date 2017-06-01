using System;
using System.Collections.Generic;
using System.Text;

namespace Markdown
{
    public class MarkdownLineSplitter : IMarkdownLineSplitter
    {
        public IEnumerable<string> Split(string markdownText)
        {
            return markdownText.Split('\n');
        }
    }
}
