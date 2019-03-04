using Microsoft.VisualStudio.TestTools.UnitTesting;
using A0;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A0.Tests
{
    [TestClass()]
    public class ProgramTests
    {
        [TestMethod()]
        public void AddTest()
        {
            long expectedReslt = 4;
            long functionResult = Program.Add(1, 3);
            Assert.AreEqual(expectedReslt, functionResult);
   
        }

        [TestMethod()]
        public void SubtractTest()
        {
            long expectedReslt = -2;
            long functionResult = Program.Subtract(1, 3);
            Assert.AreEqual(expectedReslt, functionResult);
        }

        [TestMethod()]
        public void NegateTest()
        {
            long expectedReslt = -1;
            long functionResult = Program.Negate(1);
            Assert.AreEqual(expectedReslt, functionResult);
        }

        [TestMethod()]
        public void ProductTest()
        {
            long expectedReslt = 3;
            long functionResult = Program.Product(1, 3);
            Assert.AreEqual(expectedReslt, functionResult);
        }

        [TestMethod()]
        public void SqrtTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void SquareTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void FactorialTest()
        {
            Assert.Fail();
        }
    }
}