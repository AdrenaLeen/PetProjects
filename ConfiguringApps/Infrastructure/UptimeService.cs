using System.Diagnostics;

namespace ConfiguringApps.Infrastructure
{
    public class UptimeService
    {
        readonly Stopwatch timer;

        public UptimeService() => timer = Stopwatch.StartNew();

        public long Uptime => timer.ElapsedMilliseconds;
    }
}
