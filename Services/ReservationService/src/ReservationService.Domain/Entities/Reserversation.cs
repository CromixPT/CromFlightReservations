using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReservationService.Domain.Entities
{
    public class Reserversation
    {
        public Reserversation(long id, DateOnly flightDate, City origin, City destination, int guests)
        {
            Id = id;
            FlightDate = flightDate;
            Origin = origin;
            Destination = destination;
            Distance = origin.GetDistance(destination);
            Guests = guests;
            Price = CalculateCurrentPrice();
        }

        public long Id { get; }
        public DateOnly FlightDate { get; }
        public City Origin { get; }
        public City Destination { get; set; }
        public double Distance { get; set; }
        public double Price { get; set; }
        public int Guests { get; set; }

        private double CalculateCurrentPrice()
        {
            var basePrice = Distance;

            var coeficent = FlightDate.DayOfWeek switch
            {
                DayOfWeek.Monday => 50.7,
                DayOfWeek.Tuesday => Distance - 10,
                DayOfWeek.Wednesday => Origin.Name.Length + Destination.Name.Length,
                _ => 1
            };

            return basePrice * coeficent;
        }
    }
}