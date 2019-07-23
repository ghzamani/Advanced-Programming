using A10;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using P1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P1.Tests
{
    [TestClass()]
    public class EquationTests
    {
        [TestMethod()]
        public void CheckZeroCoeffTest()
        {
            List<string> eq = new List<string>() { "2x+3y=0", "2y=4" };
            List<string> var = new List<string>() { "2x", "3y", "2y" };
            List<string> result = new List<string>() { "2x+3y=0", "2y+0x=4" };
            CollectionAssert.AreEqual(result, new Equation().CheckZeroCoeff(eq, var));

            List<string> eq2 = new List<string>() { "2a+b=0", "a+2c=5", "a+b=3" };
            List<string> var2 = new List<string>() { "2a", "b", "a", "2c", "a", "b" };
            List<string> result2 = new List<string>() { "2a+b+0c=0", "a+2c+0b=5", "a+b+0c=3" };
            CollectionAssert.AreEqual(result2, new Equation().CheckZeroCoeff(eq2, var2));
        }              


        [TestMethod()]
        public void InitializeNumsTest()
        {
            Equation equ = new Equation();
            List<string> Equations = new List<string>() { "-3u + 6y = -7", "2x+3y =6", "-2a+5b= 40" };
            Matrix<double> result = new Matrix<double>(3, 1)
            {
                new Vector<double>(1){-7},
                new Vector<double>(1){6},
                new Vector<double>(1){40}
            };
            Assert.AreEqual(equ.InitializeNums(Equations), result);
        }

        [TestMethod()]
        public void InitializeCoeffTest()
        {
            Equation equ = new Equation();
            equ.Equations = new List<string>() { "2x+3y-44k=9" , "5y+4x+9k=3" , "-30k+7y+2x=8"};
            List<string> variables = new List<string>() { "2x", "3y", "-44k", "5y", "4x", "9k", "-30k", "7y", "2x" };
            SquareMatrix<double> result = new SquareMatrix<double>(3, 3)
            {
                new Vector<double>(3){2,3,-44 },
                new Vector<double>(3){4,5,9 },
                new Vector<double>(3){2,7,-30 }
            };
            Assert.AreEqual(result, equ.InitializeCoeff(variables, 3));
        }
        
    }
}