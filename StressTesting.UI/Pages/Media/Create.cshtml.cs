using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using StressTesting.UI.Data;
using StressTesting.UI.DataModel;

namespace StressTesting.UI.Pages.Media
{
    public class CreateModel : PageModel
    {
        private readonly StressTesting.UI.Data.StressTestingUIContext _context;

        public CreateModel(StressTesting.UI.Data.StressTestingUIContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public MediaData MediaData { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.MediaData.Add(MediaData);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
