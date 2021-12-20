using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using TravelGuideApp.Models;

namespace TravelGuideApp.Repositories.Interfaces
{
    public class TouristicSiteRepository : ITouristicSiteRepository
    {
        protected readonly ApplicationDbContext _dbContext;
        public TouristicSiteRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }
        public async Task<TouristicSite> GetTouristicSiteById(int id)
        {
            return await _dbContext.TouristicSite
                .FirstOrDefaultAsync(p => p.Id == id);
        }
        public async Task<IEnumerable<Activity>> GetActivitiesByTS(int id){

            return await _dbContext.Activity
               .Where(p=>p.TouristicSite.Id==id)
               .AsNoTracking()
                .ToListAsync();


        }
        public async Task<IEnumerable<TouristicSite>> GetTouristicSitelByName(string name)
        {
            return await _dbContext.TouristicSite
                     .Where(p => string.IsNullOrEmpty(name) || p.Name.ToLower().Contains(name.ToLower()))
                     .OrderBy(p => p.Name)
                     .ToListAsync();
        }

        public async Task<IEnumerable<TouristicSite>> GetTouristicSites()
        {
            return await _dbContext.TouristicSite
                 .Include(c => c.Address)
                .AsNoTracking()
                .ToListAsync();
        }

        public  async Task<IEnumerable<Review>> GetReviewsByTouristicSite(int id)
        {
           
             return await _dbContext.Review
                .Include(c => c.TouristicSite)
                .Where(c => c.TouristicSite.Id == id)
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



