using System;
using System.Threading;
using System.Threading.Tasks;

namespace EventDelegateThread
{
    public class SingleReminderTask : ISingleReminder
    {
        Task ReiminderTask = null;
        private string _msg;
        private int _delay;

        public SingleReminderTask(string msg, int delay)
        {
            this._msg = msg;
            this._delay = delay;

            ReiminderTask = new Task(() => Reminder(Msg));
        }

        public int Delay => _delay;

        public string Msg => _msg;

        public event Action<string> Reminder;

        public void Start()
        {
            ReiminderTask.Start();
            ReiminderTask.Wait(Delay);
        }
    }
}