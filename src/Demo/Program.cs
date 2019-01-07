using BootsNoteCson;
using System;
using System.Collections.Generic;
using System.IO;

namespace Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            string notePath = @"E:\OneDrive\Boostnote\notes\";

            notePath = @"G:\OneDrive\Boostnote\notes\";
            //string path = notePath + @"0d34f0f5-2698-4cd0-90fa-b4aff1b5c5ec.cson";


            //string cson = File.ReadAllText(path);
            //var aa = CsonConvert.DeserializeObject(cson);

            //path = notePath + @"1402a8dc-4a3e-47cb-8d07-d358acd58833.cson";
            //string cson2 = File.ReadAllText(path);
            //var bb = CsonConvert.DeserializeObject(cson2);

            //path = notePath + @"c5198b74-e1a4-4b8c-a606-9d36acfde798.cson";
            //string cson3 = File.ReadAllText(path);
            //var cc = CsonConvert.DeserializeObject(cson3);

            List<NoteModel> models = new List<NoteModel>();

            var filePaths = Directory.GetFiles(notePath);
            foreach (var item in filePaths)
            {
                string cson = File.ReadAllText(item);
                var model = CsonConvert.DeserializeObject(cson);
                if (model != null)
                {
                    models.Add(model);
                }
            }

            foreach (var item in models)
            {
                Console.WriteLine($"title:{item.title}");
            }

            Console.ReadKey();

        }
    }
}
