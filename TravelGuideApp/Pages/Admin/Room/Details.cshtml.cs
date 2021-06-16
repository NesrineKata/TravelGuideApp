using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TravelGuideApp.Models;

namespace TravelGuideApp.Pages.Admin.Room
{
    public class DetailsModel : PageModel
    {
        private readonly TravelGuideApp.Models.ApplicationDbContext _context;

        public DetailsModel(TravelGuideApp.Models.ApplicationDbContext context)
        {
            _context = context;
        }

        public Models.Room Room { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Room = await _context.Room
                .Include(r => r.Hotel).FirstOrDefaultAsync(m => m.Id == id);

            if (Room == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
