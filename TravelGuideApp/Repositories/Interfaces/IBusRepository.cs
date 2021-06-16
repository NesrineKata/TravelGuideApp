using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelGuideApp.Models;

namespace TravelGuideApp.Repositories.Interfaces
{
    public interface IBusRepository 
    {
        Task<IEnumerable<Bus>> GetBuses();
        Task<Bus> GetBuslById(int id);
       

        Task<IEnumerable<Bus>> GetBusesByHotel(int id);
        Task<IEnumerable<Bus>> GetBusesByTouristicSite(int id);



    }
}
