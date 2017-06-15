using System;
using System.Collections.Generic;
using System.Text;

namespace Markdown
{
    public class MarkdownParser : IMarkdownParser
    {
        // make readonly
        private IMarkdownLineSplitter _lineSplitter;
        private IMarkdownLineParser _lineParser;

        // required?
        public MarkdownParser() : this(new MarkdownLineSplitter(), new MarkdownLineParser())
        {
        }

        // required?
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
            return _lineParser.ParseLines(_lineSplitter.Split(markdown));
        }
    }
}

