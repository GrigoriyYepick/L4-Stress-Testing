using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StressTesting.UI.Data;
using StressTesting.UI.DataModel;

namespace StressTesting.UI.Pages.Media
{
    public class IndexModel : PageModel
    {        
        private readonly IMediaDataProvider _mediaDataProvider;

        public IndexModel(IMediaDataProvider mediaDataProvider)
        {            
            _mediaDataProvider = mediaDataProvider;
        }

        public IList<MediaData> MediaData { get;set; }

        public async Task OnGetAsync()
        {
            MediaData = await _mediaDataProvider.Read();
        }
    }
}
