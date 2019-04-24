using Microsoft.VisualStudio.TestTools.UnitTesting;
using A1S1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace A1S1.Tests
{
    [TestClass()]
    public class ProgramTests
    {
        [TestMethod()]
        public void MainTest()
        {

        }

        [TestMethod()]
        public void CalculateLengthTest()
        {
            Assert.AreEqual(21, Program.CalculateLength("this is a test string"));
        }

        [TestMethod()]
        public void LetterCountTest()
        {
            Assert.AreEqual(16, Program.LetterCount("من همیشه سر وقت هستم"));
        }

        [TestMethod()]
        public void LineCountTest()
        {
            string myTest = "salam\n" +
                "this\n" +
                "is\n" +
                "my\n" +
                "test";
            Assert.AreEqual(5, Program.LineCount(myTest));
        }

        [TestMethod()]
        public void FileLineCountTest()
        {
            int lineCount;
            int charCount;
            string path = GetTestFile(out lineCount, out charCount);
            Assert.AreEqual(lineCount, Program.FileLineCount(path));
        }
        private static string GetTestFile(out int lineCount, out int charCount)
        {
            charCount = 0;
            string tmpFile = Path.GetTempFileName();
            lineCount = new Random(0).Next(10, 100);
            List<string> lines = new List<string>();
            for (int i = 0; i < lineCount; i++)
            {
                string line = $"Line number {i}";
                charCount += line.Length;
                lines.Add(line);
            }
            File.WriteAllLines(tmpFile, lines);
            return tmpFile;
        }

        [TestMethod()]
        public void ListFilesTest()
        {
            string tempDir;
            string[] example = GetTestDir(out tempDir);
            string[] funcResult = Program.ListFiles(tempDir);
            Array.Sort(example);
            CollectionAssert.AreEqual(example, funcResult );

        }
        private static string[] GetTestDir(out string tmpDir)
        {
            tmpDir = Path.GetTempFileName();
            if (File.Exists(tmpDir))
                File.Delete(tmpDir);

            if (!Directory.Exists(tmpDir))
                Directory.CreateDirectory(tmpDir);
            else
                foreach (string file in Directory.GetFiles(tmpDir))
                    File.Delete(file);

            int rndNum = new Random(0).Next(10, 20);
            List<string> files = new List<string>();
            for (int i = 0; i < rndNum; i++)
            {
                string fileName = Path.Combine(tmpDir, $"file{i}.txt");
                File.WriteAllText(fileName, $"file{i}.txt content");
                files.Add(fileName);
            }
            return files.ToArray();
        }

        [TestMethod()]
        public void FileSizeTest() 
        {
            int lineCount;
            int charCount;
            string path = GetTestFile(out lineCount, out charCount);
            Assert.AreEqual(charCount, Program.FileSize(path));
        }
    }
}