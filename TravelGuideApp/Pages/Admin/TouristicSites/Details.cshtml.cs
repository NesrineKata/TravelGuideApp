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
    public class DetailsModel : PageModel
    {
        private readonly TravelGuideApp.Models.ApplicationDbContext _context;

        public DetailsModel(TravelGuideApp.Models.ApplicationDbContext context)
        {
            _context = context;
        }

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
    }
}
