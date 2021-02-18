using System.Diagnostics;

namespace ConfiguringApps.Infrastructure
{
    public class UptimeService
    {
        Stopwatch timer;

        public UptimeService() => timer = Stopwatch.StartNew();

        public long Uptime => timer.ElapsedMilliseconds;
    }
}
