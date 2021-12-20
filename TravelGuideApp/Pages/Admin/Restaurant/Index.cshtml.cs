using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TravelGuideApp.Models;

namespace TravelGuideApp.Pages.Admin.Restaurant
{
    public class IndexModel : PageModel
    {
        private readonly TravelGuideApp.Models.ApplicationDbContext _context;

        public IndexModel(TravelGuideApp.Models.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Models.Restaurant> Restaurant { get;set; }

        public async Task OnGetAsync()
        {
            Restaurant = await _context.Restaurant.ToListAsync();
        }
    }
}
