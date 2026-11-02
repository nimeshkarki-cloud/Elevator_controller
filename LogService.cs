using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;

namespace ElevatorApp
{
    public class LogService
    {
        public class Entry { public string Elevator; public int Floor; public string Action; }

        readonly ElevatorLog db;
        readonly BackgroundWorker saver = new BackgroundWorker();
        readonly BackgroundWorker loader = new BackgroundWorker();

        readonly object queueLock = new object();
        readonly Queue<Entry> pending = new Queue<Entry>();

        public bool AutoRefresh;
        public event Action<DataTable> Loaded;
        public event Action<Exception> Failed;

        public LogService(ElevatorLog db)
        {
            this.db = db;

            saver.DoWork += (s, e) =>
            {
                while (true)
                {
                    Entry x;
                    lock (queueLock)
                    {
                        if (pending.Count == 0) break;
                        x = pending.Dequeue();
                    }
                    if (x != null) db.Add(x.Floor, x.Action, x.Elevator);
                }
            };

            saver.RunWorkerCompleted += SaverDone;
            loader.DoWork += (s, e) => e.Result = db.Load();
            loader.RunWorkerCompleted += LoaderDone;
        }

        public void Save(string elevator, int floor, string action)
        {
            lock (queueLock)
            {
                pending.Enqueue(new Entry { Elevator = elevator, Floor = floor, Action = action });
            }
            SaveNext();
        }

        void SaveNext()
        {
            if (!saver.IsBusy) saver.RunWorkerAsync();
        }

        void SaverDone(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null && Failed != null) Failed(e.Error);
            if (AutoRefresh) Load();

            lock (queueLock)
            {
                if (pending.Count > 0) SaveNext();
            }
        }

        public void Load()
        {
            if (!loader.IsBusy) loader.RunWorkerAsync();
        }

        void LoaderDone(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null) { if (Failed != null) Failed(e.Error); }
            else if (Loaded != null) Loaded((DataTable)e.Result);
        }
    }
}