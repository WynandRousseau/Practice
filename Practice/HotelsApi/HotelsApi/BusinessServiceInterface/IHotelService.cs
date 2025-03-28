using HotelsApi.Models;

namespace HotelsApi.BusinessServiceInterface
{
    public interface IHotelService
    {
        // Not fully implemented ( ran out of time )
        public Task<IEnumerable<Hotel>> GetNearestUser(IEnumerable<Hotel> hotels);

    }
}
