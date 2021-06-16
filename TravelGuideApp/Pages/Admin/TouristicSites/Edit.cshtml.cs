using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TravelGuideApp.Models;

namespace TravelGuideApp.Pages.Admin.TouristicSites
{
    public class EditModel : PageModel
    {
        private readonly TravelGuideApp.Models.ApplicationDbContext _context;

        public EditModel(TravelGuideApp.Models.ApplicationDbContext context)
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

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(TouristicSite).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TouristicSiteExists(TouristicSite.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool TouristicSiteExists(int id)
        {
            return _context.TouristicSite.Any(e => e.Id == id);
        }
    }
}
