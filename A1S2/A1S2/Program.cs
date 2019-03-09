using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A1S2
{
    class Program
    {
        static void Main(string[] args)
        {

        }

        public static double FolSize(string folder)
        {
            double size = 0;

            if (!Directory.Exists(folder))
                return size;
            else
            {
                foreach (string file in Directory.GetFiles(folder))
                {
                    if (File.Exists(file))
                    {
                        FileInfo vol = new FileInfo(file);
                        size += vol.Length;
                    }
                }

                foreach (string dir in Directory.GetDirectories(folder))
                    size += FolSize(dir);
            }
            return size;
        }
    }
}


