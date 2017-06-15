using System;
using System.Collections.Generic;
using System.Text;

namespace Markdown
{
    public interface IMarkdownParser
    {
        // rename to describe what it returns?
        string Parse(string markdown);
    }
}
