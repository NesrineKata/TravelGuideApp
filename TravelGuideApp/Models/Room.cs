using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TravelGuideApp.Models
{
    public class Room
    {

        [Key]
        public int Id { get; set; }
        public int Num { get; set; }
        public string TypeRoom { get; set; }
        public double Price { get; set; }
        public int HotelID { get; set; }
        public Hotel Hotel { get; set; }

    }
}
