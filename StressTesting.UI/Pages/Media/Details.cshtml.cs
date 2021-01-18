using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StressTesting.UI.Data;
using StressTesting.UI.DataModel;

namespace StressTesting.UI.Pages.Media
{
    public class DetailsModel : PageModel
    {        
        private readonly IMediaDataProvider _mediaDataProvider;

        public DetailsModel(         
            IMediaDataProvider mediaDataProvider)
        {            
            _mediaDataProvider = mediaDataProvider;
        }

        public MediaData MediaData { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            MediaData = await _mediaDataProvider.Read(id.Value);

            if (MediaData == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
