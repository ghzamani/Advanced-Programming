using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A1S1
{
    public class Program
    {
        public static void Main(string[] args)
        {
        }

        public static int CalculateLength(string str)
        {
            return str.Length;
        }

        public static int LetterCount(string str)
        {
            int letterCount = 0;
            for (int i = 0; i < str.Length; i++)
            {
                if (char.IsLetter(str[i]))
                    letterCount++;
            }
            return letterCount;
        }

        public static int LineCount(string str)
        {
            int lineCount = 0;
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == '\n')
                {
                    lineCount++;
                }
            }
            return lineCount + 1;
        }

        public static int FileLineCount(string filePath)
        {
            int fileLineCount = 0;
            string input = File.ReadAllText(filePath);
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '\n')
                {
                    fileLineCount++;
                }
            }
            return fileLineCount;
        }

        public static string[] ListFiles(string dirPath)
        {
            string[] contents = Directory.GetFiles(dirPath);       
            return contents;
        }

            public static double FileSize(string filePath)
            {
                int newLineCount = 1;
                string input = File.ReadAllText(filePath);
                for (int i = 0; i < input.Length; i++) {
                    if (input[i] == '\n')
                        newLineCount++;
                }
                return (input.Length - 2 * (newLineCount - 1));
            }
        }
    }


