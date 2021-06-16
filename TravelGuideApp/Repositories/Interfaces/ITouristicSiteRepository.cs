using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelGuideApp.Models;

namespace TravelGuideApp.Repositories.Interfaces
{
    public interface ITouristicSiteRepository
    {
        Task<IEnumerable<TouristicSite>> GetTouristicSites();
        Task<TouristicSite> GetTouristicSiteById(int id);
        Task<IEnumerable<TouristicSite>> GetTouristicSitelByName(string name);
        Task<IEnumerable<Activity>> GetActivitiesByTS(int id);
        Task<IEnumerable<Review>> GetReviewsByTouristicSite(int id);
        
        public void saveReview(Review r);
    }
}
