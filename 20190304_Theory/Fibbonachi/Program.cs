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

           using (FileStream fs = File.OpenRead("fibbonachi.txt"))
            {
                byte[] buffer = new byte[fs.Length];
                fs.Read(buffer, 0, buffer.Length);

                result = Encoding.UTF8.GetString(buffer);
                //Console.WriteLine(result + " result.Length = " + result.Length);
            }
                        
            List<int> fibbonachiOld = result.Split(' ').Select(n => Convert.ToInt32(n)).ToList();
            int iterations = fibbonachiOld.Count;
            for (int i = 0; i < iterations; ++i)
            {
                
                fibbonachiOld.Add(fibbonachiOld[fibbonachiOld.Count-1]+fibbonachiOld[fibbonachiOld.Count-2]);
            }

            string newFibbonachi = string.Join(" ", fibbonachiOld.ToArray());
            //using (var fs = File.OpenWrite("fibbonachi.txt"))
            //{
                File.WriteAllText("fibbonachi.txt", string.Join(" ", newFibbonachi));
                //byte[] buffer = new byte[newFibbonachi.Length * sizeof(char)];
                //System.Buffer.BlockCopy(newFibbonachi.ToCharArray(), 0, buffer, 0, buffer.Length);
                //fs.Write(buffer, 0, buffer.Length);
           // }
           

            

           // Console.ReadLine();
        }
    }
}
