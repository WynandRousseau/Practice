using HotelsApi.Models;

namespace HotelsApi.BusinessLogic
{
    public class DistanceLogic
    {
        public User FindNearestUser(Hotel hotel, IEnumerable<User> users)
        {
            return users.OrderBy(user => GetDistance(user.Geo, hotel.Location)).FirstOrDefault();
        }

        public IEnumerable<Hotel> FindNearestUserPerHotel(IEnumerable<Hotel> hotels, IEnumerable<User> users)
        {
            if (hotels == null || !hotels.Any() || users == null || !users.Any())
            {
                return [];
            }

            List<Hotel> returnlist = [];

            foreach (var hotel in hotels)
            {
                hotel.NearestUser = FindNearestUser(hotel, users);
                returnlist.Add(hotel);
            }

            return returnlist;
        }

        private double GetDistance(GeoLocation geo1, GeoLocation geo2)
        {
            double lat1 = double.Parse(geo1.Lat);
            double lng1 = double.Parse(geo1.Lng);
            double lat2 = double.Parse(geo2.Lat);
            double lng2 = double.Parse(geo2.Lng);

            var R = 6371; // Earth radius in km
            var dLat = ToRadians(lat2 - lat1);
            var dLng = ToRadians(lng2 - lng1);

            var a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) +
                    Math.Cos(ToRadians(lat1)) * Math.Cos(ToRadians(lat2)) *
                    Math.Sin(dLng / 2) * Math.Sin(dLng / 2);
            var c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
            return R * c;
        }

        private double ToRadians(double angle)
        {
            return angle * Math.PI / 180;
        }
    }
}
