using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TravelGuideApp.Models;

namespace TravelGuideApp.Pages.Admin.Bus
{
    public class DetailsModel : PageModel
    {
        private readonly TravelGuideApp.Models.ApplicationDbContext _context;

        public DetailsModel(TravelGuideApp.Models.ApplicationDbContext context)
        {
            _context = context;
        }

        public Models.Bus Bus { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Bus = await _context.Bus
                .Include(b => b.Depart)
                .Include(b => b.Destination)
                .Include(b => b.Transport).FirstOrDefaultAsync(m => m.NumLine == id);

            if (Bus == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
