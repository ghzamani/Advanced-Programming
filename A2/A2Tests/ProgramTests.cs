using Microsoft.VisualStudio.TestTools.UnitTesting;
using A2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A2.Tests
{
    [TestClass()]
    public class ProgramTests
    {
        [TestMethod()]
        public void AssignPiTest()
        {
            Program.AssignPi(out double pi);
            double expected = Math.PI;
            Assert.AreEqual(expected, pi);
        }

        [TestMethod()]
        public void SquareTest()
        {
            int a = 8;
            Program.Square(ref a);
            Assert.AreEqual(64, a);
        }

        [TestMethod()]
        public void SwapTest()
        {
            int a = 59;
            int b = 95;
            Program.Swap(ref a, ref b);
            Assert.AreEqual(95, a);
            Assert.AreEqual(59, b);
        }

        [TestMethod()]
        public void SumTest()
        {
            Program.Sum(out int sum1, 1, 2, 3, 4, 5, 6);
            Assert.AreEqual(21, sum1);

            Program.Sum(out int sum2, 8, 12, 70);
            Assert.AreEqual(90, sum2);
        }

        [TestMethod()]
        public void AppendTest()
        {
            int[] test = new int[] { 9, 8, 7 };
            Program.Append(ref test, 3);
            int[] expected = new int[] { 9, 8, 7, 3 };
            CollectionAssert.AreEqual(expected, test);
        }

        [TestMethod()]
        public void AbsArrayTest()
        {
            int[] expected = new int[] { 1, 2, 3, 0, 4, 5, 6 };
            int[] test = new int[] { -1, 2, -3, 0, -4, 5, -6 };
            Program.AbsArray(ref test);
            CollectionAssert.AreEqual(expected, test);
        }

        [TestMethod()]
        public void ArraySwapTest()
        {
            int[] test1 = new int[] { 15, 14, 13, 12 };
            int[] test2 = new int[] { 10, 20, 30, 40 };
            Program.ArraySwap( test1,  test2);
            int[] expected1 = new int[] { 10, 20, 30, 40 };
            int[] expected2 = new int[] { 15, 14, 13, 12 };

            CollectionAssert.AreEqual(expected1, test1);
            CollectionAssert.AreEqual(expected2, test2);
        }

        [TestMethod()]
        public void ArraySwap2Test()
        {
            int[] test1 = new int[] { 2, 3, 4 };
            int[] test2 = new int[] { 5 };
            Program.ArraySwap(ref test1,ref test2);
            int[] expected1 = { 5 };
            int[] expected2 = { 2, 3, 4 };
            CollectionAssert.AreEqual(expected1,test1);
            CollectionAssert.AreEqual(expected2, test2);
        }
    }
}