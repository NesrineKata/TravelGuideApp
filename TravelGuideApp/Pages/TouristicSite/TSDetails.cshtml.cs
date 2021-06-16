using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TravelGuideApp.Models;
using TravelGuideApp.Repositories.Interfaces;

namespace TravelGuideApp.Pages.TouristicSite
{
    public class TSDetailsModel : PageModel
    {
        private readonly ITouristicSiteRepository _siteRepo;
        public TSDetailsModel(ITouristicSiteRepository siteRepository)
        {
            _siteRepo = siteRepository ?? throw new ArgumentNullException(nameof(siteRepository));
        }
        public IEnumerable<Models.TouristicSite> TSList { get; set; } = new List<Models.TouristicSite>();
        //[BindProperty(SupportsGet = true)]
        public IEnumerable<Models.Activity> Activity { get; set; } = new List<Models.Activity>();
        public IEnumerable<Models.Review> reviews { get; set; } = new List<Models.Review>();


        public Models.TouristicSite Ts { get; set; }
        public async Task<IActionResult> OnGetAsync(int? tsid)
        {

            if (tsid == null)
            {
                return NotFound();
            }
         Ts = await _siteRepo.GetTouristicSiteById(tsid.Value);
            reviews = await _siteRepo.GetReviewsByTouristicSite(tsid.Value);
            if (Ts == null)
            {
                return NotFound();
            }
            Activity = await _siteRepo.GetActivitiesByTS(tsid.Value);

            return Page();

        }
        [BindProperty]
        public Review r { get; set; }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }


            _siteRepo.saveReview(r);


            return RedirectToPage("Index");


        }
    }
}
