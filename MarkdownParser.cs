using System;
using System.Collections.Generic;
using System.Text;

    public class MarkdownParser : IMarkdownParser
    {
        public string Parse(string markdown)
        {
            return Markdown.Parse(markdown);
        }
    }

