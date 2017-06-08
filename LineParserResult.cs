using System;
using System.Collections.Generic;
using System.Text;

namespace Markdown
{
    public class ParserResult
    {
        public string ParsedText { get; private set; }
        public bool InList { get; private set; }

        public ParserResult(string parsedText, bool inList)
        {
            ParsedText = parsedText;
            InList = inList;
        }
    }
}
