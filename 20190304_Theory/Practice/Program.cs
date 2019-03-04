using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

//1.	Написать программу, читающую побайтно заданный файл и подсчитывающую число появлений каждого из 256 возможных знаков.
namespace Practice
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = string.Empty;
            Console.WriteLine("Insert path to file which you read");
            path = Console.ReadLine();

            using (var fileStream = File.OpenRead(path))
            {
                byte[] buffer = new byte[];
            };
        }
    }
}
