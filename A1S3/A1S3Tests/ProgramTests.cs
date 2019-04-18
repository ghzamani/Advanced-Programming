using Microsoft.VisualStudio.TestTools.UnitTesting;
using A1S3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A1S3.Tests
{
    [TestClass()]
    public class ProgramTests
    {
        [TestMethod()]
        public void Q1_GetWordsTest()
        {
            string path = @"C:\git\AP97982\A1S3\A1S3\Get Words Test.txt";
            string[] real = Program.Q1_GetWords(path);
            string[] expected = { "Hi", "This", "is", "a", "test", "for", "AP", "class", "have", "a", "nice", "day" };

            CollectionAssert.AreEqual(expected, real);
        }

        [TestMethod()]
        public void Q2_IsInWordsTest()
        {
            string[] words = { "sun", "moon", "universe" };
            string word1 = "sun";
            bool real1 = Program.Q2_IsInWords(words, word1);
            bool b1 = true;
            string word2 = "star";
            bool real2 = Program.Q2_IsInWords(words, word2);
            bool b2 = false;
            Assert.AreEqual(b1, real1);
            Assert.AreEqual(b2, real2);
        }

        [TestMethod()]
        public void Q3_GetWordsOfTweetTest()
        {
            string test = "آن کس که نداند، و نداند که نداند";
            string[] splited = Program.Q3_GetWordsOfTweet(test);
            string[] expected = { "آن", "کس", "که", "نداند", "و", "نداند", "که", "نداند" };
            CollectionAssert.AreEqual(expected, splited);
        }

        [TestMethod()]
        public void Q4_GetPopChargeOfTweetTest()
        {
            string tweet = "اگر از دید دیگرانی، پیرزن یعنی حقیر و کوچک! اما از دید ما، پیرزن یعنی زیبایی، شجاعت، قدرت";
            string[] posWords = { "قدرت", "شجاعت", "زیبایی" };
            string[] negWords = { "کوچک", "حقیر" };

            int result = Program.Q4_GetPopChargeOfTweet(tweet, posWords, negWords);
            int expected = 1;
            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void Q5_GetAvgPopChargeOfTweetsTest()
        {
            string[] tweets = { "چاقال عين بچه ها شرو كرده بود فيلم گرفتن",
                "من عاشق متانت و گفتار وزین شما هستم" , " به هر قیمت سقوط نکنه " , 
                    "به امید اصلاح صدا و سیما" ,
                    ". تا کور شود هر آنکه نتواند دید" };
            string[] posWords = { "امید", "اصلاح", "وزین", "متانت" };
            string[] negWords = { "کور", "چاقال", "سقوط" };
            Assert.AreEqual((double)1/7 , Program.Q5_GetAvgPopChargeOfTweets( tweets,  negWords, posWords));
        }
    }
}