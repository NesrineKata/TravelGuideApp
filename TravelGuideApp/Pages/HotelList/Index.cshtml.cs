using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TravelGuideApp.Models;

namespace TravelGuideApp.Pages.HotelList
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;
       
        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public IEnumerable<Hotel> Hotels { get; set; }


        public  async void OnGetAsync()
        {
            Hotels = await _db.Hotel.ToListAsync();

        }
        [BindProperty]
        public Hotel Hotel { get; set; }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _db.Hotel.Add(Hotel);
            await _db.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
