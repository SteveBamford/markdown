using System;
using System.Collections.Generic;
using System.Text;

namespace Markdown
{
    //TODO Move common functionality into abstract base class
    public class ParagraphLineParserElement : ILineParserElement
    {
        public string ParseElement(string markdownLine, bool inListBeforeLine, out bool inListAfterLine)
        {
            //TODO Implement paragraph logic
            throw new NotImplementedException();
        }
    }
}
