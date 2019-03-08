using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SumOFTwoNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var fs = File.OpenRead("file.txt"))
            {
                byte[] buffer = new byte[fs.Length];
                fs.Read(buffer, 0, buffer.Length);

                result = Encoding.UTF8.GetString(buffer);
            }
        }
    }
}
