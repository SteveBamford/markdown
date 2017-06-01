using System;
using System.Collections.Generic;
using System.Text;

namespace Markdown
{
    public class MarkdownParser : IMarkdownParser
    {
        private IMarkdownLineSplitter _lineSplitter;
        private IMarkdownLineParser _lineParser;

        public MarkdownParser() : this(new MarkdownLineSplitter(), new MarkdownLineParser())
        {
        }

        public MarkdownParser(IMarkdownLineSplitter lineSplitter) : this(lineSplitter, new MarkdownLineParser())
        {
        }

        public MarkdownParser(IMarkdownLineSplitter lineSplitter, IMarkdownLineParser lineParser)
        {
            _lineSplitter = lineSplitter;
            _lineParser = lineParser;
        }

        public string Parse(string markdown)
        {
            var lines = _lineSplitter.Split(markdown);
            return _lineParser.ParseLines(lines);
        }
    }
}

