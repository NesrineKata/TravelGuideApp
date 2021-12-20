using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelGuideApp.Models;
using TravelGuideApp.Repositories.Interfaces;

namespace TravelGuideApp.Repositories
{
    public class HotelRepository : IHotelRepository
    {
        protected readonly ApplicationDbContext _dbContext;
        public HotelRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public Task<Address> GetAddressByHotel(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Hotel> GetHotelById(int id)
        {
            return await _dbContext.Hotel
                .Include(p=> p.Address)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Hotel>> GetHotelByName(string name)
        {
            return await _dbContext.Hotel
                     .Where(p => string.IsNullOrEmpty(name) || p.Name.ToLower().Contains(name.ToLower()))
                     .OrderBy(p => p.Name)
                     .ToListAsync();
        }

        public async Task<IEnumerable<Hotel>> GetHotles()
        {
            return await _dbContext.Hotel
                .Include(c => c.Address)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<IEnumerable<Review>> GetReviewsByHotel(int id)
        {
            return await _dbContext.Review
                .Include(c => c.Hotel)
                .Where(c=>c.Hotel.Id==id)
                .AsNoTracking()
                .ToArrayAsync();
            
        }

        public async void saveReview(Review r)
        {  
                _dbContext.Review.Add(r);
               await _dbContext.SaveChangesAsync();
        }
    }
}
