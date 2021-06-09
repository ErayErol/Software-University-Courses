namespace Chronometer
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;

    public class Chronometer : IChronometer
    {
        private const string TimeFormat = "{0:00}:{1:00}.{2:0000}";
        private Stopwatch stopWatch;
        private TimeSpan ts;

        public Chronometer()
        {
            this.Laps = new List<string>();
            this.stopWatch = new Stopwatch();
        }

        public string GetTime
            => GetTimeMethod();

        public List<string> Laps { get; }

        public void Start()
        {
            this.stopWatch.Start();
        }

        public void Stop()
        {
            this.stopWatch.Stop();
        }

        public string Lab()
        {
            string elapsedTime = this.GetTimeMethod();
            CheckTime(elapsedTime);
            return elapsedTime;
        }

        public void Reset()
        {
            this.Laps.Clear();
            this.stopWatch.Reset();
        }

        private string GetTimeMethod()
        {
            this.ts = stopWatch.Elapsed;
            string elapsedTime = String.Format(TimeFormat, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
            return elapsedTime;
        }

        private void CheckTime(string elapsedTime)
        {
            if (elapsedTime != "00:00.0000")
            {
                this.Laps.Add(elapsedTime);
            }
        }
    }
}