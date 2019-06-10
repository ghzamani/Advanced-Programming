using System;
using System.Threading;

namespace EventDelegateThread
{
    public class SingleReminderThreadPool : ISingleReminder
    {
        private int _delay;
        private string _msg;
       
        public SingleReminderThreadPool(string msg, int delay)
        {
            _msg = msg;
            _delay = delay;
        }

        public int Delay => _delay;

        public string Msg => _msg;

        public event Action<string> Reminder;

        public void Start()
        {
            ThreadPool.QueueUserWorkItem(o => Reminder(Msg));
            Thread.Sleep(Delay);
        }
    }
}