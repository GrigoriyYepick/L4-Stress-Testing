using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using StressTesting.UI.Data;
using StressTesting.UI.DataModel;

namespace StressTesting.UI.Pages.Media
{
    public class DeleteModel : PageModel
    {
        private readonly StressTesting.UI.Data.StressTestingUIContext _context;

        public DeleteModel(StressTesting.UI.Data.StressTestingUIContext context)
        {
            _context = context;
        }

        [BindProperty]
        public MediaData MediaData { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            MediaData = await _context.MediaData.FirstOrDefaultAsync(m => m.Id == id);

            if (MediaData == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            MediaData = await _context.MediaData.FindAsync(id);

            if (MediaData != null)
            {
                _context.MediaData.Remove(MediaData);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
