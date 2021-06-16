using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TravelGuideApp.Models;

namespace TravelGuideApp.Pages.Admin.Hotel
{
    public class DetailsModel : PageModel
    {
        private readonly TravelGuideApp.Models.ApplicationDbContext _context;

        public DetailsModel(TravelGuideApp.Models.ApplicationDbContext context)
        {
            _context = context;
        }

        public Models.Hotel Hotel { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Hotel = await _context.Hotel.FirstOrDefaultAsync(m => m.Id == id);

            if (Hotel == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
