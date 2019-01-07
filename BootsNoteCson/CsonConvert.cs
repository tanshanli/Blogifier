using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace BootsNoteCson
{
    public static class CsonConvert
    {
        public static NoteModel DeserializeObject(string value)
        {
            //StringBuilder sbd = new StringBuilder(value);
            //Regex reg = new Regex("(?<=(createdAt: \")).*?(?=(\"))");
            //var aa= reg.Match(value);
            //var bb = aa.Value;
            NoteModel noteModel = new NoteModel();

            //创建时间
            var createdAtStr = GetMatchValue(value, "createdAt: \"", "\"");
            DateTime.TryParse(createdAtStr, out DateTime createdAt);
            noteModel.createdAt = createdAt;

            //修改时间
            var updatedAtStr = GetMatchValue(value, "updatedAt: \"", "\"");
            DateTime.TryParse(updatedAtStr, out DateTime updatedAt);
            noteModel.updatedAt = updatedAt;

            //笔记类型
            var type = GetMatchValue(value, "type: \"", "\"");
            if (type == "SNIPPET_NOTE")
            {
                noteModel.NoteType = NoteType.SNIPPET_NOTE;
            }
            else
            {
                noteModel.NoteType = NoteType.MARKDOWN_NOTE;
            }

            //所属文件夹
            var folder = GetMatchValue(value, "folder: \"", "\"");
            noteModel.folder = folder;

            //标题
            var title = GetMatchValue(value, "title: \"", "\"");
            noteModel.title = title;

            //标签
            var tagStr = GetMatchValue(value, "tags: \\[", "\\]").Trim('\n');
            if (!string.IsNullOrWhiteSpace(tagStr))
            {
                var tagContent = tagStr.Split('\n');
                noteModel.tags = new string[tagContent.Length];
                for (int i = 0; i < tagContent.Length; i++)
                {
                    var temp = tagContent[i];
                    var s = temp.IndexOf('"') + 1;
                    var e = temp.LastIndexOf('"');
                    var tag = temp.Substring(s, e - s);
                    noteModel.tags[i] = tag;
                }
            }

            //是否星标
            var isStarred = GetMatchValue(value, "isStarred: ", "\\n");
            if (isStarred.Trim().ToLower() == "true")
            {
                noteModel.isStarred = true;
            }
            else
            {
                noteModel.isStarred = false;
            }

            //是否删除
            var isTrashed = GetMatchValue(value, "isTrashed: ", "\\n");
            if (isTrashed.Trim().ToLower() == "true")
            {
                noteModel.isTrashed = true;
            }
            else
            {
                noteModel.isTrashed = false;
            }

            //根据笔记类型，获取笔记内容
            if (noteModel.NoteType == NoteType.SNIPPET_NOTE)
            {
                var description = GetMatchValue(value, "description: \"", "\"");
                noteModel.description = description;
                noteModel.snippetNote = GetSnippetNotes(value);
            }
            else
            {
                var content = GetMatchValue(value, "content: '''", "'''", true);
                noteModel.markdownNote = new MarkdownNote();
                noteModel.markdownNote.content = content;
            }
            return noteModel;
        }

        public static List<SnippetNote> GetSnippetNotes(string value)
        {
            List<SnippetNote> snippetNotes = new List<SnippetNote>();
            var snippets = GetMatchValues(value, "  {", "\\n  }");
            foreach (var item in snippets)
            {
                snippetNotes.Add(GetSnippetNote(item));
            }
            return snippetNotes;
        }

        public static SnippetNote GetSnippetNote(string value)
        {
            SnippetNote snippetNote = new SnippetNote();
            //名称
            var name = GetMatchValue(value, "name: \"", "\"");
            snippetNote.name = name;
            //编程语言
            var mode = GetMatchValue(value, "mode: \"", "\"");
            snippetNote.mode = mode;
            //内容
            var content = GetMatchValue(value, "content: '''", "'''", true);
            snippetNote.content = content;

            return snippetNote;
        }

        /// <summary>
        /// 获取需要的内容
        /// </summary>
        /// <param name="value">源字符串</param>
        /// <param name="start">匹配起始位置</param>
        /// <param name="end">匹配结束位置</param>
        /// <param name="isGreed">是否贪婪匹配</param>
        /// <returns></returns>
        public static string GetMatchValue(string value, string start, string end, bool isGreed = false)
        {
            var matchStr = ".*?";
            if (isGreed)
            {
                matchStr = ".*";
            }
            Regex rg = new Regex($"(?<=({start})){matchStr}(?=({end}))", RegexOptions.Multiline | RegexOptions.Singleline);
            return rg.Match(value).Value;
        }

        public static List<string> GetMatchValues(string value, string start, string end, bool isGreed = false)
        {
            List<string> list = new List<string>();

            var matchStr = ".*?";
            if (isGreed)
            {
                matchStr = ".*";
            }
            Regex rg = new Regex($"(?<=({start})){matchStr}(?=({end}))", RegexOptions.Multiline | RegexOptions.Singleline);
            var matches = rg.Matches(value);
            for (int i = 0; i < matches.Count; i++)
            {
                list.Add(matches[i].Value);
            }
            return list;
        }
    }
}
