using BootsNoteCson;
using System.IO;

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
            string path = @"G:\OneDrive\Boostnote\notes\0d34f0f5-2698-4cd0-90fa-b4aff1b5c5ec.cson";
            path = @"G:\OneDrive\Boostnote\notes\c5198b74-e1a4-4b8c-a606-9d36acfde798.cson";

            string cson = File.ReadAllText(path);
            var aa = CsonConvert.DeserializeObject(cson);

        }
    }
}
