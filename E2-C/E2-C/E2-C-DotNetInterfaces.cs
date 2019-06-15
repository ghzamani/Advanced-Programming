using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

namespace E2
{
    public static class DotNetInterfaces
    {
        public static IEnumerable<long> GetElapsedTimes(int max=100)
        {
            int[] array = new int[max];
            Stopwatch s = new Stopwatch();

            for (int i = 0; i < max; i++)
            {
                s.Start();
                if (i == 0)
                    yield return 0;
                s.Stop();
                yield return s.ElapsedMilliseconds;
            }
            
        }
    }
}