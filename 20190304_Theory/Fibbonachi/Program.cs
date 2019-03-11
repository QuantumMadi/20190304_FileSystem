using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Fibbonachi
{
    class Program
    {
        static void Main(string[] args)
        {
            string result = string.Empty;
            using (FileStream fs = File.Open("fibbonachi.txt", FileMode.OpenOrCreate))
            {
                if (fs.Length == 0)
                {
                    fs.Close();
                    File.WriteAllText("fibbonachi.txt", string.Join("", "1 1 2 3 5"));

                }
            }
            using (FileStream fs = File.Open("fibbonachi.txt", FileMode.OpenOrCreate))
            {
                byte[] buffer = new byte[fs.Length];
                fs.Read(buffer, 0, buffer.Length);

                result = Encoding.UTF8.GetString(buffer);

            }                                 
            List<int> fibbonachiOld = result.Split(' ').Select(n => Convert.ToInt32(n)).ToList();
            int iterations = fibbonachiOld.Count;
            for (int i = 0; i < iterations; ++i)
            {                
                fibbonachiOld.Add(fibbonachiOld[fibbonachiOld.Count-1]+fibbonachiOld[fibbonachiOld.Count-2]);
            }
            string newFibbonachi = string.Join(" ", fibbonachiOld.ToArray());
            File.WriteAllText("fibbonachi.txt", string.Join(" ", newFibbonachi));
            
        }
    }
}
