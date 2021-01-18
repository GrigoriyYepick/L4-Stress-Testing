using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StressTesting.UI.DataModel;

namespace StressTesting.UI.Data
{
    public class StressTestingUIContext : DbContext
    {
        public StressTestingUIContext (DbContextOptions<StressTestingUIContext> options)
            : base(options)
        {
        }

        public DbSet<StressTesting.UI.DataModel.MediaData> MediaData { get; set; }
    }
}
