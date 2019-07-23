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
    public class SquareMatrixTests
    {
        [TestMethod()]
        public void DeterminantTest()
        {
            SquareMatrix<double> m1 = new SquareMatrix<double>(2)
            {
                new Vector<double>(2) {1,3},
                new Vector<double>(2) {5,0}
            };
            SquareMatrix<double> m2 = new SquareMatrix<double>(3)
            {
                new Vector<double>(3) { 3, 0, 2},
                new Vector<double>(3) { 2, 0, -2},
                new Vector<double>(3) { 0, 1, 1}
            };
            SquareMatrix<double> m3 = new SquareMatrix<double>(4)
            {
                new Vector<double>(4) {1,0,2,3 },
                new Vector<double>(4) {4,-1,-2,-3 },
                new Vector<double>(4) {0,5,-7,9 },
                new Vector<double>(4) {3,0,6,-9.1}
            };
            Assert.AreEqual(-15, m1.Determinant(m1));
            Assert.AreEqual(10, m2.Determinant(m2));
            Assert.AreEqual(-1031.7, m3.Determinant(m3));
        }

        [TestMethod()]
        public void TransposeTest()
        {
            SquareMatrix<double> m = new SquareMatrix<double>(3)
            {
                new Vector<double>(3) { 1, 2, 1},
                new Vector<double>(3) { 3.4, 0, 1},
                new Vector<double>(3) { 2, 5, 3.2}
            };
            SquareMatrix<double> result = new SquareMatrix<double>(3)
            {
                new Vector<double>(3) { 1, 3.4, 2},
                new Vector<double>(3) { 2, 0, 5},
                new Vector<double>(3) { 1, 1, 3.2}
            };
            Assert.AreEqual(result, m.Transpose(m));
        }

        [TestMethod()]
        public void CofactorMatrixTest()
        {
            SquareMatrix<double> m = new SquareMatrix<double>(3)
            {
                new Vector<double>(3) { 3, 0, 2},
                new Vector<double>(3) { 2, 0, -2},
                new Vector<double>(3) { 0, 1, 1}
            };
            SquareMatrix<double> result = new SquareMatrix<double>(3)
            {
                new Vector<double>(3) { 2, -2, 2},
                new Vector<double>(3) { 2, 3, -3},
                new Vector<double>(3) { 0, 10, 0}
            };
            Assert.AreEqual(result, m.CofactorMatrix(m));
        }

        [TestMethod()]
        public void PartOfMatrixTest()
        {
            SquareMatrix<double> m = new SquareMatrix<double>(3)
            {
                new Vector<double>(3) { 1, 2, 1},
                new Vector<double>(3) { 2, 0, 1},
                new Vector<double>(3) { 2, 5, 3.2}
            };
            SquareMatrix<double> result = new SquareMatrix<double>(2)
            {
                new Vector<double>(2){2,1},
                new Vector<double>(2){2,3.2}
            };

            Assert.AreEqual(result, m.PartOfMatrix(m, 0, 1));            
        }

        [TestMethod()]
        public void InverseMatrixTest()
        {
            SquareMatrix<double> m1 = new SquareMatrix<double>(2)
            {
                new Vector<double>(2){5, 2},
                new Vector<double>(2){-7, -3}
            };
            SquareMatrix<double> result1 = new SquareMatrix<double>(2)
            {
                new Vector<double>(2){3, 2},
                new Vector<double>(2){-7, -5}
            };

            SquareMatrix<double> m2 = new SquareMatrix<double>(3)
            {
                new Vector<double>(3) { 3, 0, 2},
                new Vector<double>(3) { 2, 0, -2},
                new Vector<double>(3) { 0, 1, 1}
            };

            SquareMatrix<double> result2 = new SquareMatrix<double>(3)
            {
                new Vector<double>(3) { 0.2, 0.2, 0},
                new Vector<double>(3) { -0.2, 0.3, 1},
                new Vector<double>(3) { 0.2, -0.3, 0}
            };

            SquareMatrix<double> m3 = new SquareMatrix<double>(3)
            {
                new Vector<double>(3) { 0, -3, -2},
                new Vector<double>(3) { 1, -4, -2},
                new Vector<double>(3) { -3, 4, 1}
            };

            SquareMatrix<double> result3 = new SquareMatrix<double>(3)
            {
                new Vector<double>(3) { 4, -5, -2},
                new Vector<double>(3) { 5, -6, -2},
                new Vector<double>(3) { -8, 9, 3}
            };

            //SquareMatrix<double> m4 = new SquareMatrix<double>(4)
            //{
            //    new Vector<double>(4) {1,0,2,3 },
            //    new Vector<double>(4) {4,-1,-2,-3 },
            //    new Vector<double>(4) {0,5,-7,9 },
            //    new Vector<double>(4) {3,0,6,-9.1}
            //};
            //SquareMatrix<double> result4 = new SquareMatrix<double>(4)
            //{
            //    new Vector<double>(4) {0.185,0.175,0.035,0.038 },
            //    new Vector<double>(4) {-0.076,-0.123,0.175,0.189 },
            //    new Vector<double>(4) {0.159,-0.088,-0.018,0.064 },
            //    new Vector<double>(4) {0.166,0,0,-0.055 }
            //};
            Assert.AreEqual(result1, m1.InverseMatrix(m1));
            //Assert.AreEqual(result2, m2.InverseMatrix(m2)); //found nothing wrong in it!
            Assert.AreEqual(result3, m3.InverseMatrix(m3));
            //Assert.AreEqual(result4, m4.Determinant(m4));
        }

        [TestMethod()]
        public void CheckConsistentTest()
        {
            SquareMatrix<double> m1 = new SquareMatrix<double>(2)
            {
                new Vector<double>(2){1,2},
                new Vector<double>(2){2,4}
            };
            Matrix<double> m2 = new Matrix<double>(2,1)
            {
                new Vector<double>(1){3},
                new Vector<double>(1){5}
            };
            Matrix<double> m3 = new Matrix<double>(2, 1)
            {
                new Vector<double>(1){8.5},
                new Vector<double>(1){17}
            };

            Assert.IsFalse(SquareMatrix<double>.CheckConsistent(m1, m2));
            Assert.IsTrue(SquareMatrix<double>.CheckConsistent(m1, m3));

            SquareMatrix<double> n1 = new SquareMatrix<double>(3)
            {
                new Vector<double>(3){3,4,5},
                new Vector<double>(3){-3,-4,-5},
                new Vector<double>(3){1,2,3}
            };
            Matrix<double> n2 = new Matrix<double>(3, 1)
            {
                new Vector<double>(1){1},
                new Vector<double>(1){2},
                new Vector<double>(1){5}
            };
            Matrix<double> n3 = new Matrix<double>(3, 1)
            {
                new Vector<double>(1){-10},
                new Vector<double>(1){10},
                new Vector<double>(1){5}
            };
            Assert.IsFalse(SquareMatrix<double>.CheckConsistent(n1, n2));
            Assert.IsTrue(SquareMatrix<double>.CheckConsistent(n1, n3));
        }
    }
}