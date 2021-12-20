using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
public enum cuisineType
{
    traditionnel,
    fastFood,
    pizzeria
}
namespace TravelGuideApp.Models
{
   
    public class Restaurant
    {

        [Key]
        public int Id { get; set; }
        public bool InHotel { get; set; }
        public cuisineType cuisineType { get; set; }
        public int Telephone { get; set; }
        public String Name { get; set; }
        public int IdAddress { get; set; }
        public Address Address { get; set; }
       
         public int? IdHotel { get; set; }

        public Hotel Hotel { get; set; }
       
        public int? IdTouristicSite { get; set; }
        public TouristicSite TouristicSite { get; set; }
        public string Url { get; set; }
        [DataType(DataType.MultilineText)]
        public string description { get; set; }
        public List<Review> Reviews { get; set; }

    }
}
