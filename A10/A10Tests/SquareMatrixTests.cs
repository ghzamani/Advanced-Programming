using Microsoft.VisualStudio.TestTools.UnitTesting;
using A10;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A10Tests
{
    [TestClass()]
    public class SquareMatrixTests
    {
            [TestMethod()]
            public void SquareMatrixTest()
            {
                SquareMatrix<int> m = new SquareMatrix<int>(3)
            {
                new Vector<int>(3) { 1, 2, 3},
                new Vector<int>(3) { 2, 3, 4},
                new Vector<int>(3) { 3, 4, 5}
            };

            for (int i = 0; i < m.RowCount; i++)
                for (int j = 0; j < m.ColumnCount; j++)
                    Assert.AreEqual(i + j + 1, m[i, j]);
            }

            [TestMethod]
            public void MultiplyTest()
            {
                SquareMatrix<int> m1 = new SquareMatrix<int>(2)
            {
                new Vector<int>(2) { 1, 2},
                new Vector<int>(2) { 10,20},
            };

                SquareMatrix<int> m2 = new SquareMatrix<int>(2)
            {
                new Vector<int>(2) { -1, 1},
                new Vector<int>(2) { 2, 0},                
            };

                var m3 = m1 * m2;

                Assert.AreEqual(3, m3[0, 0], "wrong value [0, 0]");
                Assert.AreEqual(1, m3[0, 1], "wrong value [0, 1]");
                Assert.AreEqual(30, m3[1, 0], "wrong value [1, 0]");
                Assert.AreEqual(10, m3[1, 1], "wrong value [1, 1]");
            }

            [TestMethod]
            [ExpectedException(typeof(InvalidOperationException))]
            public void MultiplyExceptionTest()
            {
                SquareMatrix<int> m1 = new SquareMatrix<int>(2)
            {
                new Vector<int>(2) {4,7},
                new Vector<int>(2) { 2, -1},
            };

                SquareMatrix<int> m2 = new SquareMatrix<int>(3)
            {
                new Vector<int>(3) { 1, 2, 1},
                new Vector<int>(3) { 2, -1, 1},
                new Vector<int>(3) { 9, 8, 7},
            };

                var m3 = m1 * m2;
            }

            [TestMethod]
            public void AddTest()
            {
                SquareMatrix<int> m1 = new SquareMatrix<int>(2)
            {
                new Vector<int>(2) { 4, 6},
                new Vector<int>(2) { 5, 7},
            };

                SquareMatrix<int> m2 = new SquareMatrix<int>(2)
            {
                new Vector<int>(2) { -5, -4},
                new Vector<int>(2) { -3, -2},
            };

                var m3 = m1 + m2;

                Assert.AreEqual(new Vector<int>(2) { -1, 2 }, m3[0]);
                Assert.AreEqual(new Vector<int>(2) { 2, 5 }, m3[1]);
            }

            [TestMethod]
            [ExpectedException(typeof(InvalidOperationException))]
            public void AddExceptionTest()
            {
                SquareMatrix<int> m1 = new SquareMatrix<int>(2)
            {
                new Vector<int>(2) { 1, 2},
                new Vector<int>(2) { 2, -1},
            };

                SquareMatrix<int> m2 = new SquareMatrix<int>(3)
            {
                new Vector<int>(3) { 0, 2, 1},
                new Vector<int>(3) { 3,4,5},
                new Vector<int>(3) { 7,8,9},
            };

                var m3 = m1 + m2;
            }

            [TestMethod]
            public void MultiplyTestLong()
            {
            SquareMatrix<int> m1 = new SquareMatrix<int>(20);
            m1[0] = new Vector<int>(Enumerable.Repeat(0, 20));
            for (int i=1; i< m1.RowCount; i++)
            {
                m1[i] = new Vector<int>(Enumerable.Repeat(1, 20));
            }

            SquareMatrix<int> m2 = new SquareMatrix<int>(20);
            for (int i = 0; i < m1.RowCount; i++)
            {
                m2[i] = new Vector<int>(Enumerable.Repeat(2, 20));
            }
            
            
                var m3 = m1 * m2;

                Assert.AreEqual(0, m3[0, 0]);
                Assert.AreEqual(0, m3[0, 3]);
                Assert.AreEqual(40, m3[1, 0]);                
            }

            [TestMethod()]
            public void EqualsTest()
            {
            SquareMatrix<int> m1 = new SquareMatrix<int>(2)
            {
                new Vector<int>(2) { 1, 2},
                new Vector<int>(2) { 2, -1},
            };

            SquareMatrix<int> m2 = new SquareMatrix<int>(2)
            {
                new Vector<int>(2) { 1, 2},
                new Vector<int>(2) { 2, -1},
            };

            SquareMatrix<int> m3 = new SquareMatrix<int>(3)
            {
                new Vector<int>(3) { 1, 2, 1},
                new Vector<int>(3) { 2, 0, 1},
                new Vector<int>(3) { 3, 4, 10},
            };

            SquareMatrix<int> m4 = new SquareMatrix<int>(3)
            {
                new Vector<int>(3) { 1, 2, 1},
                new Vector<int>(3) { 2, 0, 1},
                new Vector<int>(3) { 2, 0, 1}
            };

                Assert.AreEqual(m1, m2);
                Assert.AreNotEqual(m1, m3);

                Assert.IsTrue(m1 == m2);
                Assert.IsTrue(m1 != m3);

                Assert.AreNotEqual(m3, m4);
                Assert.IsFalse(m3 == m4);
                Assert.IsTrue(m3 != m4);
            }

            [TestMethod()]
            public void IEnumerableTest()
            {
            SquareMatrix<int> m1 = new SquareMatrix<int>( 3)
            {
                new Vector<int>(3) { 0, 1, 2},
                new Vector<int>(3) { 3, 4, 5},
                new Vector<int>(3) { 6, 7, 8},
            };

                int idx = 0;
                foreach (var vec in m1)
                    foreach (var item in vec)
                        Assert.AreEqual(idx++, item);
            }


            [TestMethod]
            public void AccessorTest()
            {
            SquareMatrix<int> m = new SquareMatrix<int>( 3)
            {
                new Vector<int>(3) { 0, 1, 2},
                new Vector<int>(3) { 3, 4, 5},
                new Vector<int>(3) { 6, 7, 8},
            };

                Assert.AreEqual(new Vector<int>(3) { 0, 1, 2 }, m[0]);
                Assert.AreEqual(new Vector<int>(3) { 3, 4, 5 }, m[1]);
                Assert.AreEqual(new Vector<int>(3) { 6, 7, 8 }, m[2]);

            for (int i = 0; i < m.RowCount; i++)
                    for (int j = 0; j < m.ColumnCount; j++)
                        Assert.AreEqual(i * 3 + j, m[i, j]);
            }

            [TestMethod]
            public void MultiAddTest()
            {
            SquareMatrix<int> m1 = new SquareMatrix<int>(2)
            {
                new Vector<int>(2) { 0, 1},
                new Vector<int>(2) { 2, 0},
            };
            SquareMatrix<int> m2 = new SquareMatrix<int>(2)
            {
                new Vector<int>(2) { 3, 0},
                new Vector<int>(2) { 4, 5},
            };

            SquareMatrix<int> m3 = new SquareMatrix<int>(2)
            {
                new Vector<int>(2) { -2, -1},
                new Vector<int>(2) { -3, 0},
            };

                var m = m1 + m2 + m3;

                Assert.AreEqual(m[0], new Vector<int>(2) { 1, 0 });
                Assert.AreEqual(m[1], new Vector<int>(2) { 3, 5 });
            }

            [TestMethod]
            public void MultiMultiplyTest()
            {
            SquareMatrix<int> m1 = new SquareMatrix<int>(2)
            {
                new Vector<int>(2) { 0, 1},
                new Vector<int>(2) { 2, -1},
            };
            SquareMatrix<int> m2 = new SquareMatrix<int>(2)
            {
                new Vector<int>(2) { -1, 1},
                new Vector<int>(2) { 1, 2},
            };

            SquareMatrix<int> m3 = new SquareMatrix<int>(2)
            {
                new Vector<int>(2) { 0, 1},
                new Vector<int>(2) { 1, 0},
            };

                var m = (m1 * m2) * m3;

                Assert.AreEqual(m[0], new Vector<int>(2) { 2, 1 });
                Assert.AreEqual(m[1], new Vector<int>(2) { 0, -3 });
            }

            [TestMethod]
            public void MultiExpressionTest()
            {
            SquareMatrix<int> m1 = new SquareMatrix<int>(2)
            {
                new Vector<int>(2) { 0, 1},
                new Vector<int>(2) { 2, -1},
            };
            SquareMatrix<int> m2 = new SquareMatrix<int>(2)
            {
                new Vector<int>(2) { -1, 1},
                new Vector<int>(2) { 1, 2},
            };

            SquareMatrix<int> m3 = new SquareMatrix<int>(2)
            {
                new Vector<int>(2) { 0, 1},
                new Vector<int>(2) { 1, 0},
            };

                var m = ((m1 + m2) * (m3 + m1)) + (m2 + m3);

                Assert.AreEqual(m[0], new Vector<int>(2) { 5, -2 });
                Assert.AreEqual(m[1], new Vector<int>(2) { 5, 7 });
            }

            [TestMethod()]
            public void MatrixToStringTest()
            {
            SquareMatrix<int> m = new SquareMatrix<int>(3)
            {
                new Vector<int>(3) { 10, 1, 2},
                new Vector<int>(3) { 20, 2, 2},
                new Vector<int>(3) { 30, 3, 3}
            };

                Assert.AreEqual("[\n[10,1,2],\n[20,2,2],\n[30,3,3]\n]", m.ToString());
            }
        }
    }
