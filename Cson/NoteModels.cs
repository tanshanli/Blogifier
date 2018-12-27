using System;

namespace BootsNoteCson
{
    public class NoteModel
    {
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime createdAt { get; set; }
        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime updatedAt { get; set; }
        /// <summary>
        /// 笔记类型
        /// </summary>
        public NoteType NoteType { get; set; }
        /// <summary>
        /// 所属文件夹编号
        /// </summary>
        public string folder { get; set; }
        /// <summary>
        /// 标签
        /// </summary>
        public string[] tags { get; set; }
        /// <summary>
        /// 标题
        /// </summary>
        public string title { get; set; }
        /// <summary>
        ///当笔记类型为 <see cref="NoteType.MARKDOWN_NOTE" />，则笔记内容在此属性里面
        /// </summary>
        public MarkdownNote markdownNote { get; set; }
        /// <summary>
        ///当笔记类型为 <see cref="NoteType.SNIPPET_NOTE" />,则笔记内容在此属性里面
        /// </summary>
        public SnippetNote snippetNote { get; set; }
        /// <summary>
        /// 是否星标
        /// </summary>
        public bool isStarred { get; set; }
        /// <summary>
        /// 是否删除
        /// </summary>
        public bool isTrashed { get; set; }
    }

    public class MarkdownNote
    {
        /// <summary>
        /// 内容
        /// </summary>
        public string content { get; set; }
    }

    public class SnippetNote
    {
        /// <summary>
        /// 代码文件名
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 编程语言
        /// </summary>
        public string mode { get; set; }
        /// <summary>
        /// 内容
        /// </summary>
        public string content { get; set; }
    }

}
