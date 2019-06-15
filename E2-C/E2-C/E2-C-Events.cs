using System;
using System.Collections.Generic;
using System.Timers;

namespace E2
{
    public class DuplicateNumberDetector
    {
        List<int> myList = new List<int>();

        public void AddNumber(int n)
        {
            if (!myList.Contains(n))
            {
                myList.Add(n);
            }
            else
            {              
                DuplicateNumberAdded(n);
            }
        }
        
        public event Action<int> DuplicateNumberAdded;
    }
}