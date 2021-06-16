using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TravelGuideApp.Models
{
    public class Hotel
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

       
        public String Url { get; set; }
        public int nbEtoile { get; set; }
        public List<Room> rooms { get; } = new List<Room>();

        public List<Bus> buses { get; set; } = new List<Bus>();

        public int IdAddress { get; set; }
        public Address Address { get; set; }

        public List<Restaurant> restaurants { get; set; } = new List<Restaurant>();
        [DataType(DataType.MultilineText)]
        public  string  description { get; set; }

        public List<Review> Reviews { get; set; }


    }   
}
