using Core.Helpers;
using System.IO;
using System.Linq;

namespace Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            //string timeStr = "2018-12-27T08:44:34.606Z";
            //DateTime dt = Convert.ToDateTime(timeStr);
            //Console.WriteLine("Hello World!");

            //2017年成考专升本政治考试高频考点试题及答案一
            string notePath = @"E:\OneDrive\Boostnote\notes\";
            string path = notePath + @"0d34f0f5-2698-4cd0-90fa-b4aff1b5c5ec.cson";
            path = notePath + @"c5198b74-e1a4-4b8c-a606-9d36acfde798.cson";

            //var aaa=File.ReadLines(path);
            //var bbb=aaa.Where(s => s.StartsWith("isStarred:")).FirstOrDefault().Replace("isStarred:", "").Trim();
            string cson = File.ReadAllText(path);
            var aa = CsonConvert.DeserializeObject(cson);

        }
    }
}
