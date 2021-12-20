using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TravelGuideApp.Models
{
    public class Transport
    {

        [Key]
        public int Id { get; set; }
        public List<Bus> buses { get; set; } = new List<Bus>();


    }
}
