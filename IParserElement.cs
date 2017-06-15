using System;
using System.Collections.Generic;
using System.Text;

namespace Markdown
{
    // not quite sure what a parserelement is, a better name might be acvhieable here.
    public interface IParserElement
    {
        // rename to describe what it returns?
        ParserResult ParseElement(string markdownLine, bool inListBeforeLine);
    }
}

