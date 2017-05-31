using System;
using System.Collections.Generic;
using System.Text;

    public class MarkdownParser : IMarkdownParser
    {
        private IMarkdownLineSplitter _lineSplitter;

        public MarkdownParser() : this(new MarkdownLineSplitter())
        {

        }

        public MarkdownParser(IMarkdownLineSplitter lineSplitter)
        {
            _lineSplitter = lineSplitter;
        }

        public string Parse(string markdown)
        {
            return Markdown.ParseLines(_lineSplitter.Split(markdown));
        }
    }

