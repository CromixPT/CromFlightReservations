namespace ReservationService.Domain.Entities
{
    public class Coordinate
    {
        public Coordinate(double latitude, double longitude)
        {
            if(!IsValidCoordinate(latitude,longitude))
            {
                throw new ArgumentException("Invalid coordinates provided");
            }

            Latitude = latitude;
            Longitude = longitude;
        }

        private static bool IsValidCoordinate(double latitude, double longitude)
        {
            if (latitude < -90 || latitude > 90) return false;
            if (longitude < -180 || longitude > 180) return false;

            return true;
        }

        public double Latitude {get;}
        public double Longitude { get;}
    }
}