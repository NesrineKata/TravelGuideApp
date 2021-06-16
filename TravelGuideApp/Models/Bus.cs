using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TravelGuideApp.Models
{
    public class Bus
    {
      
        [Key]
        public int NumLine { get; set; }
        public int HotelID { get; set; }
        public Hotel Depart { get; set; }
        public int TouristicSiteID { get; set; }
        public TouristicSite Destination { get; set; }
        public int TransportID { get; set; }
        public Transport  Transport{ get; set; }
        public string Url { get; set; }
        [DataType(DataType.MultilineText)]
        public string description { get; set; }
        public String Schedule { get; set; }
    }
}
