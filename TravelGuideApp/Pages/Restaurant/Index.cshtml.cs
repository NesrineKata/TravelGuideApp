using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TravelGuideApp.Repositories.Interfaces;

namespace TravelGuideApp.Pages.Restaurant
{
    public class IndexModel : PageModel
    {
        private readonly IRestaurantRepository _restRepo;
        public IndexModel(IRestaurantRepository restRepository)
        {
            _restRepo = restRepository ?? throw new ArgumentNullException(nameof(restRepository));
        }
        public IEnumerable<Models.Restaurant> restList { get; set; } = new List<Models.Restaurant>();
        //[BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }
        public async Task<IActionResult>  OnGetAsync()
        {
            restList = await _restRepo.GetRestaurants();
            return Page();
        }

    }
}
