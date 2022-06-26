namespace ReservationService.Domain.Entities
{
    public class Country
    {
        public Country(long id, string name)
        {
            Id = id;
            Name = name;
        }

        public long Id { get; }
        public string Name { get; }
    }
}