using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TravelGuideApp.Models;
using TravelGuideApp.Repositories.Interfaces;

namespace TravelGuideApp.Pages.Hotel
{
    public class HotelDetailsModel : PageModel
    {
        private readonly IHotelRepository _hotelRepo;
        
        private readonly IRoomRepository _roomRepo;
        public HotelDetailsModel(IHotelRepository hotelRepository,IRoomRepository roomRepo)
        {
            _hotelRepo = hotelRepository ?? throw new ArgumentNullException(nameof(hotelRepository));
            _roomRepo = roomRepo ?? throw new ArgumentNullException(nameof(roomRepo));

        }
        //public IEnumerable<Models.Hotel> HotelList { get; set; } = new List<Models.Hotel>();
        public IEnumerable<Models.Room> RoomList { get; set; } = new List<Models.Room>();
        public List<Models.Room> list { get; set; } = new List<Models.Room>();

        public IEnumerable<Models.Review> reviews { get; set; } = new List<Models.Review>();

        
        
        public Models.Hotel Hotel { get; set; }
      
        int _id { get; set; }
        [BindProperty]
        public Review  r { get; set; }
        public DateTime date = System.DateTime.Now;
        public async Task<IActionResult> OnGetAsync(int? hotelid)
        {
           
            if (hotelid == null)
            {

                return NotFound();
            }
           

            Hotel = await _hotelRepo.GetHotelById(hotelid.Value);
            RoomList = await _roomRepo.GetRoomByHotel(hotelid.Value);
            reviews = await _hotelRepo.GetReviewsByHotel(hotelid.Value);
           foreach(var r in RoomList)
            {
                if (existRoom(r) == false)
                    list.Add(r);
            }
          

            if (Hotel == null)
            {
                return NotFound();
            }
            return Page();

        }
         public async Task<IActionResult> OnPostAsync()
        {  if (!ModelState.IsValid)
               {
                   return Page();
               }
         
          
                _hotelRepo.saveReview(r);
            
           
            return RedirectToPage("Index");


        }

           
        Boolean existRoom(Room r)
        {
            foreach(var l in list)
            {
                if (l.TypeRoom.ToLower().Contains(r.TypeRoom.ToLower()))
                {
                    return true;
                }
            }
            return false;
        }

    }
}
