﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Markdown
{
    public interface IMarkdownParser
    {
        string Parse(string markdown);
    }
}
