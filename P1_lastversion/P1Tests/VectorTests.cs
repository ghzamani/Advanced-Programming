using Microsoft.VisualStudio.TestTools.UnitTesting;
using A10;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A10.Tests
{
    [TestClass()]
    public class VectorTests
    {
        [TestMethod()]
        public void MultipledVectorsTest()
        {
            Vector<double> v1 = new Vector<double>(3) { 1, 2, 3 };
            Vector<double> v2 = new Vector<double>(3) { 1.5, 2.5, 3.5 };
            Vector<double> v3 = new Vector<double>(3) { -2, -4, -6 };

            //Vector<double> v4 = new Vector<double>(2) { 0, 4 };
            //Vector<double> v5 = new Vector<double>(2) { 0, 2 };
            Vector<double> v6 = new Vector<double>(1) { 2 };
            Vector<double> v7 = new Vector<double>(1) { 5 };


            Assert.IsFalse(Vector<double>.MultipledVectors(v1, v2));
            Assert.IsTrue(Vector<double>.MultipledVectors(v1, v3));
            //Assert.IsTrue(Vector<double>.MultipledVectors(v4, v5));
            Assert.IsTrue(Vector<double>.MultipledVectors(v6, v7));
        }
    }
}