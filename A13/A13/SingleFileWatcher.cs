using System;
using System.IO;

namespace EventDelegateThread
{

    public class SingleFileWatcher: IDisposable
    {
        private FileSystemWatcher Watcher;

        private Action myDelegate;
       
        public SingleFileWatcher(string path)
        {            
            Watcher = new FileSystemWatcher(Path.GetDirectoryName(path));
            Watcher.Filter = Path.GetFileName(path);
            Watcher.EnableRaisingEvents = true;
        }
        
        public void Register(Action action)
        {            
            myDelegate += action;
            Watcher.Changed += new FileSystemEventHandler(OnChanged);         
        }

        public void Unregister(Action action)
        {
            myDelegate -= action;
            //Watcher.Changed -= OnChanged;
            
        }

        private void OnChanged(object sender, FileSystemEventArgs e)
        {
            myDelegate();
        }
                
        public void Dispose()
        {
            Watcher.Dispose();
        }
    }
}