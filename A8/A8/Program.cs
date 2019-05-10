using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A8
{
    public class Human
    {
        public string FirstName;
        public string LastName;
        public DateTime BirthDate;
        public double Height;

        public Human(string firstName, string lastName, DateTime birthDate, double height)
        {
            FirstName = firstName;
            LastName = lastName;
            BirthDate = birthDate;
            Height = height;
        }

        public Human() { } //default constructor is used for SumOverrideTset

        public static Human operator +(Human h , Human h2)
        {
            h.FirstName = "ChildFirstName";
            h.LastName = "ChildLastName";
            DateTime d2 = new DateTime(DateTime.Now.Year,
                DateTime.Now.Month, DateTime.Now.Day);
            h.BirthDate = d2;
            h.Height = 30;
            return h;
        }

        public static bool IsSmaller(int a1 , int a2)
        {
            return a1 < a2;
        }

        public static bool IsBigger(int a1, int a2)
        {
            return a1 > a2;
        }

        public static bool IsSmallerOrEqual(int a1, int a2)
        {
            return a1 <= a2;
        }

        public static bool IsBiggerOrEqual(int a1, int a2)
        {
            return a1 >= a2;
        }

        public static bool operator < (Human h1 , Human h2)
        {
            if (h1.BirthDate.Year == h2.BirthDate.Year)
            {
                if(h1.BirthDate.Month == h2.BirthDate.Month)
                {
                    return IsBigger(h1.BirthDate.Day , h2.BirthDate.Day);
                }
                else return IsBigger(h1.BirthDate.Month, h2.BirthDate.Month);
            }
            else return IsBigger(h1.BirthDate.Year, h2.BirthDate.Year);
        }

        public static bool operator > (Human h1, Human h2)
        {
            if (h1.BirthDate.Year == h2.BirthDate.Year)
            {
                if (h1.BirthDate.Month == h2.BirthDate.Month)
                {
                    return IsSmaller(h1.BirthDate.Day , h2.BirthDate.Day);
                }
                else return IsSmaller(h1.BirthDate.Month, h2.BirthDate.Month);
            }
            else return IsSmaller(h1.BirthDate.Year, h2.BirthDate.Year);
        }

        public static bool operator <= (Human h1, Human h2)
        {
            if (h1.BirthDate.Year == h2.BirthDate.Year)
            {
                if (h1.BirthDate.Month == h2.BirthDate.Month)
                {
                    return IsBiggerOrEqual(h1.BirthDate.Day , h2.BirthDate.Day);
                }
                else return IsBigger(h1.BirthDate.Month, h2.BirthDate.Month);
            }
            else return IsBigger(h1.BirthDate.Year, h2.BirthDate.Year);
        }

        public static bool operator >= (Human h1, Human h2)
        {
            if (h1.BirthDate.Year == h2.BirthDate.Year)
            {
                if (h1.BirthDate.Month == h2.BirthDate.Month)
                {
                    return IsSmallerOrEqual(h1.BirthDate.Day, h2.BirthDate.Day);
                }
                else return IsSmaller(h1.BirthDate.Month, h2.BirthDate.Month);
            }
            else return IsSmaller(h1.BirthDate.Month, h2.BirthDate.Month);
        }

        public override bool Equals(object obj)
        {
            Human h = obj as Human;
            return (h.FirstName == this.FirstName && h.LastName == this.LastName &&
            h.BirthDate == this.BirthDate &&
            h.Height == this.Height);
        }
        
        public override int GetHashCode()
        {
            return FirstName.GetHashCode() ^ LastName.GetHashCode() ^
                BirthDate.GetHashCode() ^ Height.GetHashCode();
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {   
        }
    }
}
