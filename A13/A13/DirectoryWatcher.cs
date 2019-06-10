using System;
using System.IO;

namespace EventDelegateThread
{
    public enum ObserverType { Create, Delete }

    public class DirectoryWatcher : IDisposable
    {
        private FileSystemWatcher Watcher;
        private Action<string> myAction;

        public DirectoryWatcher(string info)
        {
            Watcher = new FileSystemWatcher(info);
            Watcher.EnableRaisingEvents = true;
        }

        public void Dispose()
        {
            Watcher.Dispose();
        }

        public void Register(Action<string> notifyMe, ObserverType observerT)
        {
            //myAction += notifyMe;
            if(observerT == ObserverType.Create)
            {
                myAction += notifyMe;
                Watcher.Created += OnCreated;                
            }
            else
            {
                myAction += notifyMe;
                Watcher.Deleted += OnDeleted;
            }
            
        }

        private void OnDeleted(object sender, FileSystemEventArgs e)
        {
            myAction(e.FullPath);
        }

        private void OnCreated(object sender, FileSystemEventArgs e)
        {
            myAction(e.FullPath);
        }

        public void Unregister(Action<string> notifyMe, ObserverType observerT)
        {
            myAction -= notifyMe;
        }
    }
}