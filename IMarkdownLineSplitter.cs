using System;
using System.Collections.Generic;
using System.Text;

    public interface IMarkdownLineSplitter
    {
        IEnumerable<string> Split(string markdownText);
    }

