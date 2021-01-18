using StressTesting.UI.DataModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StressTesting.UI.Data
{
    public interface IMediaDataProvider
    {
        Task<IList<MediaData>> Read();

        Task<MediaData> Read(int id);
    }
}
