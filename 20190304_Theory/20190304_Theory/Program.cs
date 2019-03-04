using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _20190304_Theory
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = string.Empty;

            Console.WriteLine("Choose index of drive, where you would preserve the file");

            DriveInfo[] drives = DriveInfo.GetDrives();
            for (int i =0; i < drives.Length; ++i)
            {
                if(drives[i].IsReady&&drives[i].DriveType==DriveType.Fixed)
                    Console.WriteLine($"{i}.{drives[i].Name}");
            }

            int position = int.Parse(Console.ReadLine());
            path += drives[position].Name;

            foreach(var directory in drives[position].RootDirectory.EnumerateDirectories()) {
                Console.WriteLine(directory.Name);
            }
            Console.WriteLine("Write name of new directory where you want to save your file");
            path +=Console.ReadLine();

            if (!Directory.Exists(path)) Directory.CreateDirectory(path);

            Console.WriteLine("Insert file name");
            path += @"\" + Console.ReadLine();
            if (!File.Exists(path))
            {
                using (File.Create(path));
            }

            string data = "Some Text";

            //using (var fileStream = new FileStream(path, FileMode.Open))
            //{
            //    byte[] bytesData = Encoding.UTF8.GetBytes(data);
            //    fileStream.Write(bytesData, 0,bytesData.Length);
            //}
            using (var fileStream = File.OpenRead(path)) 
            {             
                byte[] buffer = new byte[fileStream.Length];
                fileStream.Read(buffer,0,buffer.Length);

                string result = Encoding.UTF8.GetString(buffer);
            }
            using (var stream = new StreamReader(path))
            {
                string text = stream.ReadToEnd();
            }

        }
    }
}
