using StressTesting.UI.DataModel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace StressTesting.UI.Data
{
    public sealed class CachedMediaDataProvider : IMediaDataProvider
    {
        private const long Ttl = 60000;
        
        private readonly IMediaDataProvider _mediaDataProvider;
        private readonly IMediaDataCache _mediaDataCache;
        private readonly Stopwatch _stopwatch = new Stopwatch();        

        public CachedMediaDataProvider(
            MediaDataProvider mediaDataProvider,
            IMediaDataCache mediaDataCache)
        {
            _mediaDataProvider = mediaDataProvider;
            _mediaDataCache = mediaDataCache;
        }

        public async Task<IList<MediaData>> Read()
        {
            return await _mediaDataProvider.Read();
            //return await ReadWithCache();
        }

        public async Task<MediaData> Read(int id)
        {
            return await _mediaDataProvider.Read(id);
        }

        private async Task<IList<MediaData>> ReadWithCache()
        {
            var value = _mediaDataCache.Read();
            var time = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();            

            if(value != null)
            {
                if (!CacheShoulBeReset(time, value.Delta, value.Expiry, Ttl))
                {
                    return value.Data;
                }
            }

            _stopwatch.Start();
            var media = await _mediaDataProvider.Read();
            _stopwatch.Stop();

            var delta = _stopwatch.ElapsedMilliseconds;
            var expiry = DateTimeOffset.UtcNow.AddMilliseconds(Ttl).ToUnixTimeMilliseconds();
            var cacheData = new CacheContainer(media, delta, expiry);

            _mediaDataCache.Write(cacheData, Ttl);

            return media;
        }

        private static bool CacheShoulBeReset(long time, long delta, long expiry, long ttl, int beta = 1)
        {
            //time() − delta * beta * log(rand(0,1)) ≥ expiry

            var diff = delta * beta * Math.Log(new Random().NextDouble());

            return time - diff >= expiry;
        }
    }
}
