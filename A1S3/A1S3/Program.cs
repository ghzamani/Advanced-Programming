using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A1S3
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string newPath = @"..\..\result.txt";

            string directoryPath = @"..\..\TwitterData\Tweets";
            string[] files = Directory.GetFiles(directoryPath); //آدرس تمام فایلها@"..\..\TwitterData\Tweets\AfsharMahnaz.txt";
            string[] fileNames = new string[files.Length]; //اسم تمام فایلها
            for(int i=0; i < files.Length; i++)
            {
                fileNames[i] = Path.GetFileName(files[i]);
            }

            string[] data2 = Program.Q1_GetWords(@"..\..\TwitterData\Words\negative.txt");
            string[] data3 = Program.Q1_GetWords(@"..\..\TwitterData\Words\positive.txt");

            StreamWriter writer = new StreamWriter(newPath);
            using (writer)
            {
                for (int i = 0; i <fileNames.Length; i++)
                {
                    writer.WriteLine(fileNames[i] + ':' +
                        Q5_GetAvgPopChargeOfTweets(Program.Q1_GetWords(files[i]), data2, data3));
                }
            }
        }

        public static string[] Q1_GetWords(string path) 
        {
            char[] delimiters = new char[] { ' ', ',', '.', '!', '?', '@', '#', '"', '\'', '\"', '،',
                '%', '*', '(', ')', '-', '_', ':', ';', '\r','\n' };
            string text = File.ReadAllText(path);
            string[] words = text.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
            return words;
        }

        public static bool Q2_IsInWords(string[] words, string word)
        {
            if (words.Contains(word))
                return true;
            else return false;
        }

        public static string[] Q3_GetWordsOfTweet(string tweet)
        {
            char[] delimiters = new char[] { ' ', ',', '.', '!', '?', '@', '#', '"', '\'', '\"', '،',
                '%', '*', '(', ')', '-', '_', ':', ';', '\r', '\n' };
            string[] splitedWords = tweet.Split(delimiters);
            return splitedWords;
        }

        public static int Q4_GetPopChargeOfTweet(string tweet, string[] posWords,
            string[] negWords)
        {
            int positiveCount = 0;
            int negativeCount = 0;
            for (int i = 0; i < posWords.Length; i++)
            {
                if (tweet.Contains(posWords[i]))
                    positiveCount++;
            }

            for (int i = 0; i < negWords.Length; i++)
            {
                if (tweet.Contains(posWords[i]))
                    negativeCount--;
            }
            return positiveCount + negativeCount;
        }

        public static double Q5_GetAvgPopChargeOfTweets(string[] tweets, string[] negWords,
            string[] posWords) 
        {
            int positiveCount = 0;
            int negativeCount = 0;
            double tedad = 0; // تعداد کلماتی که هم در توییت ها بوده هم در آرایه لغات مثبت و منفی
            for (int j = 0; j < tweets.Length; j++)
            {
                string[] tweetWords = Q3_GetWordsOfTweet(tweets[j]);
                foreach (string word in tweetWords)
                {
                    if (posWords.Contains(word))
                    {
                        positiveCount++;
                        tedad++;
                    }
                    if (negWords.Contains(word))
                    {
                        negativeCount++;
                        tedad++;
                    }
                }
            }
            double average = (positiveCount - negativeCount) / tedad;  //تقسیم  بر تعداد کلماتی که چک شده
            return average;
        }
    }
}
