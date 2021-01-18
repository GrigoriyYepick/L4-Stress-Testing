using Microsoft.EntityFrameworkCore;
using StressTesting.UI.DataModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StressTesting.UI.Data
{
    public class MediaDataProvider : IMediaDataProvider
    {
        private readonly StressTestingUIContext _context;

        public MediaDataProvider(StressTestingUIContext context)
        {
            _context = context;
        }

        public async Task<IList<MediaData>> Read()
        {
            return await _context.MediaData.ToListAsync();
        }

        public async Task<MediaData> Read(int id)
        {
            return await _context.MediaData.FirstOrDefaultAsync(m => m.Id == id);
        }
    }
}
