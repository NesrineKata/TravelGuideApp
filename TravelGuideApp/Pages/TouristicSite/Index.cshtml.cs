using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TravelGuideApp.Repositories.Interfaces;

namespace TravelGuideApp.Pages.TouristicSite
{
    public class IndexModel : PageModel
    {

        private readonly ITouristicSiteRepository _siteRepo;
        public IndexModel(ITouristicSiteRepository siteRepository)
        {
            _siteRepo = siteRepository ?? throw new ArgumentNullException(nameof(siteRepository));
        }
        public IEnumerable<Models.TouristicSite> TSList { get; set; } = new List<Models.TouristicSite>();
        //[BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }
        public async Task<IActionResult> OnGetAsync()
        {
            TSList = await _siteRepo.GetTouristicSites();
            return Page();
        }
    }
}
