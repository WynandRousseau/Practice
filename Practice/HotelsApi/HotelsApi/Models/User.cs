namespace HotelsApi.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public GeoLocation Geo { get; set; }

        public double NearestDistance { get; set; }
    }
}
