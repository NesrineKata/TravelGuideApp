using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TravelGuideApp.Models
{
    public class TouristicSite
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int YearsOfSeniority { get; set; }
        public List<Activity> activities { get; set; } = new List<Activity>();
        public int IdAddress { get; set; }
        public Address Address { get; set; }
        public string Url { get; set; }
        [DataType(DataType.MultilineText)]
        public string description { get; set; }
        public List<Review> Reviews { get; set; }
    }
}
