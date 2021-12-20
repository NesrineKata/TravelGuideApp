using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TravelGuideApp.Models;

namespace TravelGuideApp.Repositories.Interfaces
{
    public class RestaurantRepository : IRestaurantRepository
    {
        protected readonly ApplicationDbContext _dbContext;
        public RestaurantRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }
       
        public async Task<IEnumerable<Restaurant>> GetRestaurants()
        {
            return //await _dbContext.Restaurant.AsNoTracking().ToListAsync();
                 await (from items in _dbContext.Restaurant

                          select new Restaurant
                          {
                              Id = items.Id,
                              Name = items.Name,
                              InHotel = items.InHotel,
                              // IdHotel = (items.IdHotel ?? 0) == 0 ? 0 : 1
                              Url = items.Url,
                              description=items.description,
                              cuisineType=items.cuisineType,
                              Address=items.Address
                          }).AsNoTracking().ToListAsync();
                
        }

       
        public async Task<IEnumerable<Restaurant>> GetRestaurantById(int id)
        {
            // return await _dbContext.Restaurant
            //.FirstOrDefaultAsync(p => p.Id == id);
            return await (from items in _dbContext.Restaurant
                          select new Restaurant
                          {
                              Id = items.Id,
                              Name = items.Name,
                              InHotel = items.InHotel,
                              // IdHotel = (items.IdHotel ?? 0) == 0 ? 0 : 1
                              Url = items.Url,
                              description = items.description,
                              cuisineType = items.cuisineType,
                              Address = items.Address,
                              Hotel = (items.Hotel ?? null) == null ? null : items.Hotel,
                              TouristicSite = (items.TouristicSite ?? null) == null ? null : items.TouristicSite,

                          })
                          .Where(p=>p.Id==id)
                          .AsNoTracking().ToListAsync();

        }

        public async Task<IEnumerable<Review>> GetReviewsByRestaurant(int id)
        {

            return await _dbContext.Review
                .Include(c => c.Restaurant)
                .Where(c => c.Restaurant.Id == id)
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
   

