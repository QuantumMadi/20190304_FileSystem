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
            string result;
            using (var fs = File.Open("input.txt", FileMode.OpenOrCreate))
            {
                                            
                if (fs.Length == 0)
                {
                    Random firstRand = new Random();
                    Random secondRand = new Random(10);
                    int qw = firstRand.Next()%100;
                    int rt = secondRand.Next() % 100;
                    fs.Close();
                    File.WriteAllText("input.txt", $"{firstRand.Next()%100} {secondRand.Next()%100}");
                }
            }

            using (var fs = File.Open("input.txt", FileMode.OpenOrCreate))
            {
                byte[] buffer = new byte[fs.Length];
                fs.Read(buffer, 0, buffer.Length);

                result = Encoding.UTF8.GetString(buffer);
            }

            List<int> twoNumbers = result.Split(' ').Select(n => Convert.ToInt32(n)).ToList();
            File.WriteAllText("output.txt", string.Join("", twoNumbers[0] + twoNumbers[1]));
        }
    }
}
