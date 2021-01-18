using StressTesting.UI.DataModel;
using System;
using System.Collections.Generic;

namespace StressTesting.UI.Data
{
    public interface IMediaDataCache
    {
        void Write(CacheContainer cache, long ttl);

        CacheContainer Read();
    }
}
