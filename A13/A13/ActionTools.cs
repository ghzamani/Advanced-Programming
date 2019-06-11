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
            s.Stop();
            return s.ElapsedMilliseconds;
        }

        public static long CallParallelThreadSafe(int count, params Action[] actions)
        {
            Stopwatch s = Stopwatch.StartNew();
            List<Task> myList = new List<Task>();
            Parallel.ForEach(actions, (action) =>
            {
                for (int i = 0; i < count; i++)
                {
                    lock (myList)
                    {
                        Task t = new Task(action);
                        t.Start();
                        t.Wait();
                    }
                }
            });
            
            s.Stop();
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
            List<Task> myList = new List<Task>();
            for (int i = 0; i < actions.Length; i++)
            {
                Task t = new Task(actions[i]);
                t.Start();
                myList.Add(t);
            }
            await Task.WhenAll(myList.ToArray());

            return s.ElapsedMilliseconds;
        }

        public static async Task<long> CallParallelThreadSafeAsync(int count, params Action[] actions)
        {
            Stopwatch s = Stopwatch.StartNew();
            List<Task> myList = new List<Task>();
            foreach (var action in actions)
            {
                Task t = (Task.Run(() =>
                {
                    for (int i = 0; i < count; i++)
                    {
                        lock (myList)
                        {
                            Task t2 = new Task(action);
                            t2.Start();
                            t2.Wait();
                        }
                    }
                }));

                myList.Add(t);
            };

            await Task.WhenAll(myList.ToArray());

            s.Stop();
            return s.ElapsedMilliseconds;
        }
    }
}