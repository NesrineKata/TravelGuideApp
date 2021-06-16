using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TravelGuideApp.Repositories.Interfaces;

namespace TravelGuideApp.Pages.Hotel
{
    public class IndexModel : PageModel
    {
        private readonly IHotelRepository _hotelRepo;
        public IndexModel(IHotelRepository hotelRepository)
        {
            _hotelRepo = hotelRepository ?? throw new ArgumentNullException(nameof(hotelRepository));
        }
        public IEnumerable<Models.Hotel> HotelList { get; set; } = new List<Models.Hotel>();
        //[BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }
        public async Task<IActionResult> OnGetAsync()
        {
           HotelList = await _hotelRepo.GetHotles();
            return Page();
        }
       
    }
}
