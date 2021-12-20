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
    public class IndexModel : PageModel
    {
        private readonly TravelGuideApp.Models.ApplicationDbContext _context;

        public IndexModel(TravelGuideApp.Models.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Models.TouristicSite> TouristicSite { get;set; }

        public async Task OnGetAsync()
        {
            TouristicSite = await _context.TouristicSite.ToListAsync();
        }
    }
}
