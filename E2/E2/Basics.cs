using System;
using System.Collections.Generic;
using System.IO;

namespace E2
{
    public class FullName
    {
        public string FirstName;
        public string LastName;

        public FullName(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }
    }

    public static class Basics
    {
        public static int CalculateSum(string expression)
        {
            if (!char.IsDigit(expression[expression.Length - 1]))
                throw new InvalidDataException();

            var str = expression.Split('+');
            List<int> nums = new List<int>();
            foreach (var s in str)
            {
                try { nums.Add(int.Parse(s)); }

                catch(Exception e) //eshtebah
                {
                    throw e;
                }
            }
            int sum = 0;
            foreach (var num in nums)
                sum += num;
            return sum;
        }

        public static bool TryCalculateSum(string expression, out int value)
        {
            try
            {
                value = CalculateSum(expression);
                return true;
            }
            catch
            {
                value = 0;
                return false;
            }            
        }

        /// <summary>
        /// {\displaystyle 1\,-\,{\frac {1}{3}}\,+\,{\frac {1}{5}}\,-\,{\frac {1}{7}}\,+\,{\frac {1}{9}}\,-\,\cdots \,=\,{\frac {\pi }{4}}.}
        /// </summary>
        /// <returns></returns>
        public static int PIPrecision()
        {
            double pi = 0;
            for(int i=0; i<int.MaxValue; i++)
            {
                //pi = pi + 1/ (2i + 1);
            }
            Math.Round(Math.PI, 7);
            throw new NotImplementedException();
        }

        public static int Fibonacci(this int n)
        {
            int[] fib = new int[n];
            fib[0] = 1;
            fib[1] = 2;
            for(int i=2; i<n; i++)
            {
                fib[i] = fib[i - 1] + fib[i - 2];
            }
            return fib[n-1];
        }

        public static void RemoveDuplicates<T>(ref T[] list)
        {
            List<T> newList = new List<T>();
            foreach (var item in list)
            {
                if (!Contains(newList, item))
                    newList.Add(item);
            }
            list = newList.ToArray();
        }

        private static bool Contains<T>(List<T> list, T lookup)
        {
            foreach (var item in list)
                if (item.Equals(lookup))
                    return true;
            return false;
        }
    }
}