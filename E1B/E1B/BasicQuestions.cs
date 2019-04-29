using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E1
{
    public class BasicQuestions
    {
        public static int OddSum(int[] nums)
        {
            int sum = 0;
            foreach(int num in nums)
            {
                if (num % 2 != 0)
                    sum += num;
            }
            return sum;
        }

        public static void Swap<_Type>(ref _Type a, ref _Type b)
        {
            _Type tmp;
            tmp = a;
            a = b;
            b = tmp;
        }
    }
}
