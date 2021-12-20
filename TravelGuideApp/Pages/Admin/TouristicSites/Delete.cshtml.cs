using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TravelGuideApp.Models;

namespace TravelGuideApp.Pages.Admin.TouristicSites
{
    public class DeleteModel : PageModel
    {
        private readonly TravelGuideApp.Models.ApplicationDbContext _context;

        public DeleteModel(TravelGuideApp.Models.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Models.TouristicSite TouristicSite { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TouristicSite = await _context.TouristicSite.FirstOrDefaultAsync(m => m.Id == id);

            if (TouristicSite == null)
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

            TouristicSite = await _context.TouristicSite.FindAsync(id);

            if (TouristicSite != null)
            {
                _context.TouristicSite.Remove(TouristicSite);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
