using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TravelGuideApp.Models;
using TravelGuideApp.Repositories.Interfaces;

namespace TravelGuideApp.Pages.Restaurant
{
    public class RestDetailsModel : PageModel
    {
        private readonly IRestaurantRepository _restRepo;
        public RestDetailsModel(IRestaurantRepository restRepository)
        {
            _restRepo = restRepository ?? throw new ArgumentNullException(nameof(restRepository));
        }
        public IEnumerable<Models.Restaurant> restList { get; set; } = new List<Models.Restaurant>();

        public Models.Restaurant Rest { get; set; }
        public IEnumerable<Models.Review> reviews { get; set; } = new List<Models.Review>();


        public async Task<IActionResult> OnGetAsync(int? restid)
        {
            if (restid == null)
            {
                return NotFound();
            }
            restList = await _restRepo.GetRestaurantById(restid.Value);
            reviews = await _restRepo.GetReviewsByRestaurant(restid.Value);
            if ( restList== null)
            {
                return NotFound();
            }
            Rest = restList.First();
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


            _restRepo.saveReview(r);


            return RedirectToPage("Index");


        }
    }
}
