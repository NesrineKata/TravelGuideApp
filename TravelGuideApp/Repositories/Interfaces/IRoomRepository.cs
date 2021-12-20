using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelGuideApp.Models;

namespace TravelGuideApp.Repositories.Interfaces
{
    public  interface IRoomRepository
    {


        public  Task<IEnumerable<Room>> GetRooms();

        public  Task<IEnumerable<Room>> GetRoomByHotel(int id);
        
        //Task<IEnumerable<TouristicSite>> GetTouristicSitelByName(string name);


    }
}
