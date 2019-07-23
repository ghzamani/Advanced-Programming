using Microsoft.VisualStudio.TestTools.UnitTesting;
using P1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using A10;

namespace P1.Tests
{
    [TestClass()]
    public class MainWindowTests
    {
        MainWindow window = new MainWindow();

        [TestMethod()]
        public void CalculatePartTest()
        {
            string f = "10x^2";
            string f2 = "5x^4";
            string f3 = "cos(x-2)";
            string f4 = "sin(x^2-3x)";
            Assert.AreEqual("40", window.CalculatePart(f, 2));
            Assert.AreEqual("80", window.CalculatePart(f2, 2));
            Assert.AreEqual("1", window.CalculatePart(f3, 2));
            Assert.AreEqual(Math.Sin(-2).ToString(), window.CalculatePart(f4, 1));
        }

        [TestMethod()]
        public void FunctionTest()
        {
            string f = "4x^2 + 3x^3 - 5";
            string f2 = "3x^2-5x^3+1";
            string f3 = "-2x^3+3x^2+2";
            string f4 = "3x+ 4x^2+ 13x^12";
            string f5 = "x-13";
            string f6 = " sin(x^2-4x + 4)+ x^3";
            string f7 = "-2x";
            Assert.AreEqual(2, window.Parse(f, 1));
            Assert.AreEqual(-1, window.Parse(f2, 1));
            Assert.AreEqual(7, window.Parse(f3, -1));
            Assert.AreEqual(14, window.Parse(f4, -1));
            Assert.AreEqual(-13, window.Parse(f5, 0));
            Assert.AreEqual(8, window.Parse(f6, 2));
            Assert.AreEqual(-20, window.Parse(f7, 10));
        }

        [TestMethod()]
        public void FactorialTest()
        {
            Assert.AreEqual(40320, window.Factorial(8));
            Assert.AreEqual(6, window.Factorial(3));
        }

        [TestMethod()]
        public void TaylorSeriesTest()
        {
            //n = 3 & a = 0
            MainWindow.f Exp1 = (input) =>
            {
                return input - Math.Pow(input, 3) / 6 + Math.Pow(input, 5) / 120;
            };

            //n = 5 & a = 0
            MainWindow.f Exp2 = (input) =>
            {
                return input - Math.Pow(input, 3) / 6 + Math.Pow(input, 5) / 120
                - Math.Pow(input, 7) / window.Factorial(7) /*+ Math.Pow(input, 9) / window.Factorial(9)*/;
            };

            //n = 3 & a = 1
            MainWindow.f Exp3 = (input) =>
            {
                return Math.Sin(1) + Math.Cos(1) * (input - 1) - Math.Sin(1) * Math.Pow((input - 1), 2) / 2;
            };

            Assert.AreEqual(Math.Round(Exp1(1), 3), Math.Round(window.TaylorSeries(3, 0)(1)), 3);
            Assert.AreEqual(Math.Round(Exp3(1), 3), Math.Round(window.TaylorSeries(3, 1)(1)), 3);
            Assert.AreEqual(Math.Round(Exp2(6), 3), Math.Round(window.TaylorSeries(4, 0)(6)), 3);
        }

        [TestMethod()]
        public void FindFPrimeTest()
        {
            Assert.AreEqual("cos(x)", window.FindFPrime(1));


            Assert.AreEqual(Math.Cos(Math.PI), window.GetFunction("cos(x)")(Math.PI));
        }

        [TestMethod()]
        public void DerivativePartTest()
        {
            string f = "2x^3";
            string res1 = "6x^2";
            string res11 = "12x^1";
            string f2 = "23";
            string res2 = "0";
            string f3 = "x";
            string res3 = "1";
            string res33 = "0";
            string f4 = "4x^6";
            string res444 = "480x^3";
            string f5 = "2sin(x^2)";
            string res5 = "(2x^1)*2cos(x^2)";
            string f6 = "cos(3x^4)";
            string res6 = "-(12x^3)*1sin(3x^4)";

            Assert.AreEqual(res1, window.DerivativeParts(f, 1));
            Assert.AreEqual(res11, window.DerivativeParts(f, 2));
            Assert.AreEqual(res2, window.DerivativeParts(f2, 1));
            Assert.AreEqual(res3, window.DerivativeParts(f3, 1));
            Assert.AreEqual(res33, window.DerivativeParts(f3, 2));
            Assert.AreEqual(res444, window.DerivativeParts(f4, 3));
            Assert.AreEqual(res5, window.DerivativeParts(f5, 1));

        }

        [TestMethod()]
        public void DerivativeTest()
        {
            string f = "2x^3+3x^5";
            string res1 = "6x^2+15x^4";
            Assert.AreEqual(res1, window.Derivative(f, 1));

            string f2 = "2x^5+3x+4";
            string res2 = "10x^4+3+0";
            Assert.AreEqual(res2, window.Derivative(f2, 1));

            string f3 = "-12x-4x^2";
            string res3 = "-12-8x^1";
            Assert.AreEqual(res3, window.Derivative(f3,1));
        }
    }

}