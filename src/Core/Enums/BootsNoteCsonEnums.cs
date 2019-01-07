using System.ComponentModel;

namespace Core.Enums
{
    public enum NoteType
    {
        [Description("Markdown博客")]
        MARKDOWN_NOTE,
        [Description("代码片段博客")]
        SNIPPET_NOTE
    }
}
