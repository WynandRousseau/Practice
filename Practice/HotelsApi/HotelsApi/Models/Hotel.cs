namespace HotelsApi.Models
{
    public class Hotel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public GeoLocation Location { get; set; }
        public User NearestUser { get; set; }
    }
}
