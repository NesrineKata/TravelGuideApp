using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelGuideApp.Models;

namespace TravelGuideApp.Repositories.Interfaces
{
    public interface IRestaurantRepository
    {
        Task<IEnumerable<Restaurant>> GetRestaurants();
        Task<IEnumerable<Restaurant>> GetRestaurantById(int id);
        Task<IEnumerable<Review>> GetReviewsByRestaurant(int id);
        
        public void saveReview(Review r);

    }
}
