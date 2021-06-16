using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TravelGuideApp.Repositories.Interfaces;

namespace TravelGuideApp.Pages.Transport
{
    public class IndexModel : PageModel
    {

        private readonly IBusRepository _busRepo;
        public IndexModel(IBusRepository busRepository)
        {
            _busRepo = busRepository ?? throw new ArgumentNullException(nameof(busRepository));
        }
        public IEnumerable<Models.Bus> busList { get; set; } = new List<Models.Bus>();
        //[BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }
        public async Task<IActionResult> OnGetAsync()
        {
            busList = await _busRepo.GetBuses();
            return Page();
        }
    }
}
