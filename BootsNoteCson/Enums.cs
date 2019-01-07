using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace BootsNoteCson
{
    public enum NoteType
    {
        [Description("Markdown博客")]
        MARKDOWN_NOTE,
        [Description("代码片段博客")]
        SNIPPET_NOTE
    }
}
