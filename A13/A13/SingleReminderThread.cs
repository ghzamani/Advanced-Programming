using System;
using System.Threading;

namespace EventDelegateThread
{
    public class SingleReminderThread : ISingleReminder
    {
        Thread ReiminderThread = null;

        private int _delay;
        private string _msg;
        public SingleReminderThread(string msg, int delay)
        {
            _delay = delay;
            _msg = msg;

            ReiminderThread = new Thread(() => Reminder(Msg));

        }

        public int Delay => _delay;

        public string Msg => _msg;

        public event Action<string> Reminder;

        public void Start()
        {
            ReiminderThread.Start();
            Thread.Sleep(Delay);
        }
    }
}