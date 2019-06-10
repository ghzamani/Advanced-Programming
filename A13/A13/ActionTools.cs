using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using System;
using System.Threading;

namespace EventDelegateThread
{
    public static class ActionTools
    {
        public static long CallSequential(params Action[] actions)
        {
            Stopwatch s = Stopwatch.StartNew();
            foreach (var action in actions)
            {
                Thread t = new Thread(() => action());
                t.Start();
                t.Join();
            }
            s.Stop();
            return s.ElapsedMilliseconds;
        }

        public static long CallParallel(params Action[] actions)
        {
            Stopwatch s = Stopwatch.StartNew();
            List<Task> myTasks = new List<Task>();
            Parallel.ForEach(actions, (action) => 
            {
                Task task = new Task(action);
                myTasks.Add(task);
                task.Start();
            });

            Task.WaitAll(myTasks.ToArray());
            
            return s.ElapsedMilliseconds;
        }

        public static long CallParallelThreadSafe(int count, params Action[] actions)
        {
            Stopwatch s = Stopwatch.StartNew();
            List<Task> myList = new List<Task>();
            Parallel.ForEach(actions, (action) =>
            {
                lock (myList)
                {
                    for (int i = 0; i < count; i++)
                    {
                        Task t = new Task(action);
                        myList.Add(t);
                        t.Start();
                    }
                }                
            });

            Task.WaitAll(myList.ToArray());
            return s.ElapsedMilliseconds;
        }


        public static async Task<long> CallSequentialAsync(params Action[] actions)
        {
            Stopwatch s = Stopwatch.StartNew();
            foreach (var action in actions)
            {
                await Task.Run(action);
            }

            return s.ElapsedMilliseconds;
        }

        public static async Task<long> CallParallelAsync(params Action[] actions)
        {
            Stopwatch s = Stopwatch.StartNew();
            Parallel.ForEach(actions, (action) =>
            {
               //await Task.Run(action);
            });
            return s.ElapsedMilliseconds;
        }

        public static async Task<long> CallParallelThreadSafeAsync(int count, params Action[] actions)
        {
            throw new NotImplementedException();
        }
    }
}