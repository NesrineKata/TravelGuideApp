using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TravelGuideApp.Models
{
    public class Review
    {

        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public int review { get; set; }

        [DataType(DataType.MultilineText)]
        public string feedback { get; set; }
        public int? HotelId { get; set; }
        public Hotel Hotel { get; set; }
        public int? RestaurantId { get; set; }
        public Restaurant Restaurant { get; set; }
        public int? touristicSiteId { get; set; }
        public TouristicSite TouristicSite { get; set; }
        

    }
}
