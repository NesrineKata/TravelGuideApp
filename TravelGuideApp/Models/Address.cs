using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TravelGuideApp.Models
{
    public class Address
    {

        [Key]
        public int Id { get; set; }

        public string address { get; set; }
        public string city { get; set; }

        public string country { get; set; }

        public List<Hotel> Hotel { get; set; } = new List<Hotel>();
        public List<Restaurant> Restaurant { get; set; } = new List<Restaurant>();

        public List<TouristicSite> touristicSite { get; set; } = new List<TouristicSite>();

        internal object FirstOrDefaultAsync(Func<object, bool> p)
        {
            throw new NotImplementedException();
        }
    }
}
