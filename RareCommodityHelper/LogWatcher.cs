using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.IO;
using System.Threading;
using System.Collections.Concurrent;
using System.Globalization;
using System.Diagnostics;

namespace RareCommodityHelper
{
    class LogWatcher
    {
        public LogWatcher(string logDirectory)
        {
            this.logDirectory = logDirectory;
            threads = new List<Thread>();

            if (logDirectory == null || logDirectory.Equals(""))
                return;  // Not configured.

            // Find the latest netLog file.
            currentLogFile = Directory.GetFiles(logDirectory, "netLog.*").Max();
            shouldShutDown = false;

            fsWatcher = new FileSystemWatcher(logDirectory, "netLog.*");
            fsWatcher.Created += this.OnFileCreated;

            threads.Add(new Thread(this.ReadLogThread));
            threads.Add(new Thread(this.BroadcastSystemThread));
            foreach (Thread t in threads) t.Start();
        }

        public string LogDirectory() {
            return logDirectory;
        }

        public StarSystem CurrentSystem()
        {
            lock (this) return currentSystem;
        }

        // Shutdown of this watcher.
        public void ShutDown()
        {
            OnSystemChanged = null;
            lock (this) shouldShutDown = true;
            foreach (Thread t in threads) t.Join();
        }

        public delegate void SystemChangedHandler(StarSystem newSystem);
        public event SystemChangedHandler OnSystemChanged;

        public void BroadcastSystemThread()
        {
            StarSystem lastKnown = null;
            while (!ShouldShutDown()) {
                StarSystem x = CurrentSystem();
                if (x != null && (lastKnown == null || x.Name != lastKnown.Name))
                {
                    Debug.WriteLine("Broadcasting arrival at " + x.Name);

                    // Note: since we only check once a second, this isn't sufficient to
                    // send a message saying "the player went from system Y to X". In
                    // particular, on startup we'll process the full log file in less
                    // than a second, and this thread will skip a lot of systems. We'll
                    // need to use a queue if we want to build maps using the player's
                    // travels.
                    if (OnSystemChanged != null)
                        OnSystemChanged(x);

                    lastKnown = x;
                }
                Thread.Sleep(1000);
            }
        }

        // This regex matches the arrival messages written to netLog files. Example message:
        //   "System:14(Kongga) Body:19 Pos:(643.377,-277.251,438.709)"
        // Capturing groups:
        //   1: system number (unused)
        //   2: system name
        //   3: body (unused)
        //   4, 5, 6: x, y, z coordinates
        static private Regex ARRIVE_IN_SYSTEM_REGEX =
            new Regex("System:(\\d+)\\((.*?)\\).*?Body:(\\d+) Pos:\\((-?\\d+\\.\\d*),(-?\\d+\\.\\d*),(-?\\d+\\.\\d*)\\)");

        static private Regex NETLOG_FILE_REGEX = new Regex("netLog\\.[.\\d]+");

        private FileSystemWatcher fsWatcher;
        private string currentLogFile;
        private StarSystem currentSystem;
        private bool shouldShutDown;
        private string logDirectory;
        private List<Thread> threads;

        private string CurrentLogFile()
        {
            lock (this) return currentLogFile;
        }

        private bool ShouldShutDown()
        {
            lock (this) return shouldShutDown;
        }

        private bool ShouldKeepReading(string logFile)
        {
            lock (this) return !shouldShutDown && currentLogFile == logFile;
        }

        private void ReadLogThread()
        {
            while (!shouldShutDown)
            {
                var f = CurrentLogFile();
                if (f != null) 
                    ReadLogFile(currentLogFile);
                else
                    Thread.Sleep(1000);
            }
        }

        private void ReadLogFile(string logFile)
        {
            Debug.WriteLine("Reading from file: " + logFile);
            using (FileStream fs = new FileStream
                (logFile, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                using (StreamReader sr = new StreamReader(fs))
                {
                    while (ShouldKeepReading(logFile))
                    {
                        if (sr.EndOfStream)
                            Thread.Sleep(100);
                        else
                            ProcessLine(sr.ReadLine());
                    }
                }
            }
        }

        // Process a new line from the current log file.
        private void ProcessLine(string line)
        {
            var m = ARRIVE_IN_SYSTEM_REGEX.Match(line);
            if (!m.Success) return;
            
            var name = m.Groups[2].Value;
            float x = float.Parse(m.Groups[4].Value, CultureInfo.InvariantCulture);
            float y = float.Parse(m.Groups[5].Value, CultureInfo.InvariantCulture);
            float z = float.Parse(m.Groups[6].Value, CultureInfo.InvariantCulture);

            var newSystem = new StarSystem();
            newSystem.Name = name;
            newSystem.Position = new Coords();
            newSystem.Position.X = x;
            newSystem.Position.Y = y;
            newSystem.Position.Z = z;

            lock (this)
            {
                if (currentSystem == null || newSystem.Name != currentSystem.Name)
                {
                    Debug.WriteLine("Found system: " + newSystem.Name);
                    currentSystem = newSystem;
                }
            }
        }

        // Called by our FileSystemWatcher when a netLog file is created.
        private void OnFileCreated(object source, FileSystemEventArgs e)
        {
            lock (this)
            {
                // Log files have an always-ascending timestamp in them, e.g. the file for 2015-1-2
                // will start with "150102...". So we should always be reading the max filename.
                if (currentLogFile.CompareTo(e.Name) < 0)
                {
                    Debug.WriteLine("Found new log file: " + e.Name);
                    currentLogFile = e.Name;
                }
            }
        }
    }
}
