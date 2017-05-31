using System;
using System.Collections.Generic;
using System.Text;

public class MarkdownLineSplitter : IMarkdownLineSplitter
{
    public IEnumerable<string> Split(string markdownText)
    {
        return markdownText.Split('\n');
    }
}
