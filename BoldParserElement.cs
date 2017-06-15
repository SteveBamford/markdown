using System;
using System.Collections.Generic;
using System.Text;

namespace Markdown
{
    public class BoldParserElement : ParserElementBase
    {
        //todo: I would remove the private statements to improve the signal to noise ratio. I won't repeat this comment everywhere
        const string BOLD_MARKDOWN_TEXT = "__";
        const string BOLD_REPLACEMENT_TEXT = "strong";

        // todo: this is a minor and stylistic point, I think putting parameters on their own line and indenting makes it easier to read more obvious if there are lots of parameters
        public override ParserResult ParseElement(string markdownLine, bool inListBeforeLine) =>
            new ParserResult(
                Parse(
                    markdownLine, 
                    BOLD_MARKDOWN_TEXT, 
                    BOLD_REPLACEMENT_TEXT), 
                inListBeforeLine);
        
    }
}
