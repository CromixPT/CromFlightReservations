namespace ReservationService.Domain.Entities
{
    public class City
    {
        public City(long id, long countryId, string name, double latitude, double longitude)
        {
            Id = id;
            CountryId = countryId;
            Name = name;
            Coordinates = new Coordinate(latitude,longitude);
        }

        public long Id { get; }
        public long CountryId {get;}
        public string Name { get;  }
        public Coordinate Coordinates { get; }
    }
}