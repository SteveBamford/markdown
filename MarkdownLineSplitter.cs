using System;
using System.Collections.Generic;
using System.Text;

namespace Markdown
{
    public class MarkdownLineSplitter : IMarkdownLineSplitter
    {
        public IEnumerable<string> Split(string markdownText)
        {
            if (markdownText == null)
                return new List<string>();
            return markdownText.Split('\n');
        }
    }
}
