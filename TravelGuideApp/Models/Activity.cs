    using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TravelGuideApp.Models
{
    public class Activity
    {
        
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string genre { get; set; }
        public double prix { get; set; }
        public int TouristicSiteID { get; set; }
        public TouristicSite TouristicSite { get; set; }


    }
}
