using StressTesting.UI.DataModel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Timers;

namespace StressTesting.UI.Data
{
    public sealed class MediaDataCache : IMediaDataCache, IDisposable
    {
        private readonly Timer _timer = new Timer();
        private readonly object _lock = new object();        
        
        private CacheContainer _cache;
        private IList<MediaData> _temp;

        public MediaDataCache()
        {
            _timer.Elapsed += _timer_Elapsed;            
        }

        public void Dispose()
        {
            _timer.Stop();
            _timer.Elapsed -= _timer_Elapsed;
            _timer.Dispose();
        }

        public void Write(CacheContainer cache, long ttl)
        {
            Trace.WriteLine("Write to cache");

            lock (_lock)
            {
                _timer.Stop();

                _cache = cache;                
                
                _timer.Interval = ttl;
                _timer.Start();               
            }
        }

        public CacheContainer Read()
        {
            lock (_lock)
            {
                return _cache;
            }
        }

        private void _timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            lock (_lock)
            {
                _cache.Data.Clear();
                _cache = null;
            }
        }
    }
}
