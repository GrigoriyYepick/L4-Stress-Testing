using StressTesting.UI.DataModel;
using System.Collections.Generic;

namespace StressTesting.UI.Data
{
    public class CacheContainer
    {
        public CacheContainer(IList<MediaData> data, long delta, long expiry)
        {
            Data = data;
            Delta = delta;
            Expiry = expiry;
        }

        internal IList<MediaData> Data { get; set; }
     
        internal long Delta { get; set; }
        
        internal long Expiry { get; set; }
    }
}
