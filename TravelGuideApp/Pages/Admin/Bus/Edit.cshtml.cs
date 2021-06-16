using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TravelGuideApp.Models;

namespace TravelGuideApp.Pages.Admin.Bus
{
    public class EditModel : PageModel
    {
        private readonly TravelGuideApp.Models.ApplicationDbContext _context;

        public EditModel(TravelGuideApp.Models.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Models.Bus Bus { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Bus = await _context.Bus
                .Include(b => b.Depart)
                .Include(b => b.Destination)
                .Include(b => b.Transport).FirstOrDefaultAsync(m => m.NumLine == id);

            if (Bus == null)
            {
                return NotFound();
            }
           ViewData["HotelID"] = new SelectList(_context.Hotel, "Id", "Id");
           ViewData["TouristicSiteID"] = new SelectList(_context.TouristicSite, "Id", "Id");
           ViewData["TransportID"] = new SelectList(_context.Transport, "Id", "Id");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Bus).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BusExists(Bus.NumLine))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool BusExists(int id)
        {
            return _context.Bus.Any(e => e.NumLine == id);
        }
    }
}
