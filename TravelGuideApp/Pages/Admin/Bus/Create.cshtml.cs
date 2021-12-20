using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TravelGuideApp.Models;

namespace TravelGuideApp.Pages.Admin.Bus
{
    public class CreateModel : PageModel
    {
        private readonly TravelGuideApp.Models.ApplicationDbContext _context;

        public CreateModel(TravelGuideApp.Models.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["HotelID"] = new SelectList(_context.Hotel, "Id", "Id");
        ViewData["TouristicSiteID"] = new SelectList(_context.TouristicSite, "Id", "Id");
        ViewData["TransportID"] = new SelectList(_context.Transport, "Id", "Id");
            return Page();
        }

        [BindProperty]
        public Models.Bus Bus { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Bus.Add(Bus);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
