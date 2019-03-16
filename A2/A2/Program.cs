using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A2
{
    public class Program
    {
        public static void Main(string[] args)
        {
        }

        public static void AssignPi(out double pi)
        {
            pi = Math.PI;
        }

        public static void Square(ref int input)
        {
            input *= input;
        }

        public static void Swap(ref int a, ref int b)
        {
            int hold;
            hold = a;
            a = b;
            b = hold;
        }

        public static void Sum (out int sum, params int[] nums)
        {
            sum = 0;
            foreach (int num in nums)
                sum += num;
        }

        public static void Append (ref int[] arr, int a)
        {
            int n = arr.Length + 1;
            Array.Resize(ref arr, n);
            arr[n-1] = a;
        }

        public static void AbsArray (ref int[] numbers)
        {
            for (int i=0; i<numbers.Length; i++)
                numbers[i] = Math.Abs(numbers[i]);
        }

        public static void ArraySwap( int[] firstArr, 
             int[] secondArr)
        {
            for(int i=0; i<firstArr.Length; i++)
            {
                int hold = 0;
                hold = firstArr[i];
                firstArr[i] = secondArr[i];
                secondArr[i] = hold;
            }
        }

        public static void ArraySwap(ref int[] firstArr,
            ref int[] secondArr)
        {
            int[] hold = firstArr;
            Array.Resize(ref firstArr, secondArr.Length);
            firstArr = secondArr;
            Array.Resize(ref secondArr, hold.Length);
            secondArr = hold;
        }
    }
}
