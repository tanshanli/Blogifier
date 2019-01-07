using Core.Data.OtherModels;
using Core.Helpers;
using System.Collections.Generic;
using System.IO;

namespace Core.Services
{
    public interface IBoostNoteService
    {
        /// <summary>
        /// 获取目录下面的所有笔记
        /// </summary>
        /// <param name="notePath"></param>
        /// <returns></returns>
        List<NoteModel> GetAllNotes(string notePath);
    }

    public class BoostNoteService : IBoostNoteService
    {
        public List<NoteModel> GetAllNotes(string notePath)
        {
            List<NoteModel> models = new List<NoteModel>();
            var filePaths = Directory.GetFiles(notePath);
            foreach (var item in filePaths)
            {
                string cson = System.IO.File.ReadAllText(item);
                var model = CsonConvert.DeserializeObject(cson);
                if (model != null)
                {
                    models.Add(model);
                }
            }

            return models;
        }
    }
}
