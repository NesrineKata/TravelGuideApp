using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using TravelGuideApp.Models;
using TravelGuideApp.Repositories.Interfaces;

namespace TravelGuideApp.Repositories
{
    public class RoomRepository : IRoomRepository
    {
        protected readonly ApplicationDbContext _dbContext;
        public RoomRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }
        public async Task<IEnumerable<Room>> GetRooms()
        {

            return await _dbContext.Room
                .Include(c => c.Hotel)
                .AsNoTracking()
                .ToListAsync();
        }
        public async Task<IEnumerable<Room>> GetRoomByHotel(int id)
        {

            //  return await _dbContext.Room.AsQueryable().Include(p => p.Hotel).Where(p => p.HotelID == id).AsAsyncEnumerable().GroupBy(b => b.TypeRoom).ToListAsync();

            return await _dbContext.Room
            .Include(m => m.Hotel)
            .Where(p => p.HotelID == id)
           /* .GroupBy(b => b.TypeRoom)
                .Select(c => new RoomType
                {
                    TypeRoom = c.TypeRoom,
                    Price = c.Price
                    //Waiting = (Math.Round(c.TIME_START_SERVICE.TotalMinutes - c.TIME_REGISTR.TotalMinutes, 2))
                })
           */
                
               .ToListAsync();
           
        }
    }
}
