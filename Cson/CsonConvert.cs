using System;
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
            var createdAtStr = GetValue(value, "createdAt: \"", "\"");
            DateTime.TryParse(createdAtStr, out DateTime createdAt);
            noteModel.createdAt = createdAt;

            //修改时间
            var updatedAtStr = GetValue(value, "updatedAt: \"", "\"");
            DateTime.TryParse(updatedAtStr, out DateTime updatedAt);
            noteModel.updatedAt = updatedAt;

            //笔记类型
            var type = GetValue(value, "type: \"", "\"");
            if (type == "SNIPPET_NOTE")
            {
                noteModel.NoteType = NoteType.SNIPPET_NOTE;
            }
            else
            {
                noteModel.NoteType = NoteType.MARKDOWN_NOTE;
            }

            var folder = GetValue(value, "folder: \"", "\"");
            noteModel.folder = folder;

            var title = GetValue(value, "title: \"", "\"");
            noteModel.title = title;

            if (noteModel.NoteType == NoteType.SNIPPET_NOTE)
            {
                
            }
            else
            {
                var content = GetValue(value, "content: '''", "'''");
                noteModel.markdownNote = new MarkdownNote();
                noteModel.markdownNote.content = content;
            }
            return noteModel;
        }

        public static string GetValue(string value, string start, string end)
        {
            Regex rg = new Regex("(?<=(" + start + "))[.\\s\\S]*(?=(" + end + "))", RegexOptions.Multiline | RegexOptions.Singleline);
            return rg.Match(value).Value;
        }
    }
}
