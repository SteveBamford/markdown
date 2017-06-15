using System;
using System.Collections.Generic;
using System.Text;

namespace Markdown
{
    public interface IMarkdownLineParser
    {
        // I've read that methods that return some should return a description of the thing they return
        // and methods that don't return anything, should indicate what they mutate in verb, noun format.
        // this might be a bit picky, but this is in verb noun format.
        // so maybe could be changed to ParsedHtml or something
        string ParseLines(IEnumerable<string> markdownLines);
    }
}

