using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelGuideApp.Models;
using TravelGuideApp.Repositories.Interfaces;

namespace TravelGuideApp.Repositories
{
    public class BusRepository : IBusRepository
    {
        protected readonly ApplicationDbContext _dbContext;

        public  BusRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }
        public async Task<IEnumerable<Bus>> GetBuses()
        {
            return await _dbContext.Bus.Include(p=>p.Depart).Include(p=>p.Destination).ToListAsync();
        }

        public async Task<IEnumerable<Bus>> GetBusesByHotel(int id)
        {
            return await _dbContext.Bus
            .Where(p => p.HotelID == id)
            .ToListAsync();

        }

        public async Task<IEnumerable<Bus>> GetBusesByTouristicSite(int id)
        {
            return await _dbContext.Bus
                .Where(p => p.TouristicSiteID == id)
                .ToListAsync();
        }

        public async Task<Bus> GetBuslById(int id)
        {
            return await _dbContext.Bus
              .FirstOrDefaultAsync(p => p.NumLine == id);
        }
    }
}
