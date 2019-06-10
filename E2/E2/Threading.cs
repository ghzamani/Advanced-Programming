using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace E2
{

    public static class Threading
    {
        
        public static void MakeItFaster(params Action[] actions)
        {
            List<Task> list = new List<Task>();
            Parallel.ForEach(actions, action =>
            {
                Task t = new Task(action);
                list.Add(t);
                t.Start();
            });

            Task.WaitAll(list.ToArray());
        }
    }
}