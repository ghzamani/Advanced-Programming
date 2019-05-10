using Microsoft.VisualStudio.TestTools.UnitTesting;
using A8;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A8.Tests
{
    [TestClass()]
    public class ProgramTests
    {

        [TestMethod]
        public void HumanConstructorTest()
        {
            DateTime d = new DateTime(2008, 12, 25); 
            Human h1 = new Human("Sara", "Sadeghi", d, 167);
            Assert.AreEqual(h1.FirstName, "Sara");
            Assert.AreEqual(h1.LastName, "Sadeghi");
            Assert.AreEqual(h1.BirthDate, d);
            Assert.AreEqual(h1.Height, 167);


            DateTime d2 = new DateTime(1990, 05, 10);
            Human h2 = new Human("Armin", "Hadadi", d2, 180);
            Assert.AreEqual(h2.FirstName, "Armin");
            Assert.AreEqual(h2.LastName, "Hadadi");
            Assert.AreEqual(h2.BirthDate, d2);
            Assert.AreEqual(h2.Height, 180);
        }

        [TestMethod]
        public void SumOverrideTest()
        {
            Human hTest = new Human();
            Human h = new Human();
            Human result = hTest + h;
            DateTime today = new DateTime(DateTime.Now.Year,
                DateTime.Now.Month, DateTime.Now.Day);
            Human expected = new Human("ChildFirstName", "ChildLastName", today , 30);

            Assert.AreEqual("ChildFirstName", result.FirstName);
            Assert.AreEqual("ChildLastName", result.LastName);
            Assert.AreEqual(today, result.BirthDate);
            Assert.AreEqual(30, result.Height);
            //Assert.ReferenceEquals(expected, result); ya be jaye 4 khate bala be in shekl
        }

        [TestMethod]
        public void SmallerThanOverrideTest()
        {
            DateTime d1 = new DateTime(2000, 10, 20);
            Human h1 = new Human("Sadaf", "Zareyee", d1 , 158);
            DateTime d2 = new DateTime(2001, 10, 20);
            Human h2 = new Human("Masoud", "Khademi", d2, 170);
            bool result = h1 < h2;
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void BiggerThanOverrideTest()
        {
            DateTime d1 = new DateTime(2000, 10, 20);
            Human h1 = new Human("Sadaf", "Zareyee", d1, 158);
            DateTime d2 = new DateTime(2000, 11, 20);
            Human h2 = new Human("Masoud", "Khademi", d2, 170);
            bool result = h1 > h2;
            Assert.AreEqual(true, result); 
        }

        [TestMethod]
        public void SmallerOrEqualOverrideTest()
        {
            DateTime d1 = new DateTime(2000, 10, 20);
            Human h1 = new Human("Sadaf", "Zareyee", d1, 158);
            DateTime d2 = new DateTime(2000, 10, 20);
            Human h2 = new Human("Masoud", "Khademi", d2, 170);
            bool result = h1 <= h2;
            Assert.AreEqual(true, result);

            DateTime d3 = new DateTime(1990, 10, 20);
            Human h3 = new Human("Donya", "Madani", d3, 158);
            DateTime d4 = new DateTime(1990, 10, 21);
            Human h4 = new Human("Hamed", "Saeedi", d4, 170);
            bool result2 = h3 <= h4;
            Assert.AreEqual(false, result2);
        }

        [TestMethod]
        public void BiggerOrEqualOverrideTest()
        {
            DateTime d1 = new DateTime(2008, 05, 08);
            Human h1 = new Human("Sadaf", "Zareyee", d1, 158);
            DateTime d2 = new DateTime(2008, 01, 20);
            Human h2 = new Human("Masoud", "Khademi", d2, 170);
            bool result = h1 >= h2;
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void EqualsTest()
        {
            DateTime d1 = new DateTime(2008, 05, 08);
            Human h1 = new Human("Mina", "Naseri", d1, 158);
            Human h2 = new Human("Mina", "Naseri", d1, 158);
            Human h3 = new Human("Masoud", "Khademi", d1, 158);
            Assert.IsFalse(Equals(h1, h3));
            Assert.IsTrue(Equals(h1, h2));
        }

        [TestMethod]
        public void GetHashCodeTest()
        {
            DateTime d1 = new DateTime(2008, 05, 08);
            Human h1 = new Human("Sadaf", "Zareyee", d1, 158);
            DateTime d2 = new DateTime(2008, 01, 20);
            Human h2 = new Human("Masoud", "Khademi", d2, 170);
            Human h3 = new Human("Nazanin", "Ashrafi", d1, 158);

            Assert.AreNotEqual(h1.GetHashCode(), h2.GetHashCode());
            Assert.AreNotEqual(h3.GetHashCode(), h2.GetHashCode());
        }

       
    }
}