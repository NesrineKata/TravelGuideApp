using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelGuideApp.Models;

namespace TravelGuideApp.Repositories.Interfaces
{
    public interface IHotelRepository
    {
        Task<IEnumerable<Hotel>> GetHotles();
        Task<Hotel> GetHotelById(int id);
        Task<IEnumerable<Hotel>> GetHotelByName(string name);

        Task<Address> GetAddressByHotel(int id);

        Task <IEnumerable<Review>> GetReviewsByHotel(int id);
        void saveReview(Review r);
    }
}
