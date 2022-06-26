namespace ReservationService.Domain.Entities
{
    public static class ExtensionMethods
    {
        public static double ToRadian(this double d)
        {
            return d * (Math.PI / 180);
        }
        public static double DiffRadian(this double val1, double val2)
        {
            return val2.ToRadian() - val1.ToRadian();
        }
        public static double GetDistance(this City origin, City destination)
        {
            return GetDistance(origin.Coordinates.Latitude,origin.Coordinates.Longitude,destination.Coordinates.Latitude,destination.Coordinates.Longitude);
        }

        private static double GetDistance(double originLatitude,double originLongitude, double destinationLatitude, double destinationLongitude)
        {
            const double radius = 6371.0;
            const int decimalPlaces = 0;
            return Math.Round(
                radius * 2 *
                Math.Asin(
                    Math.Min(
                        1,
                        Math.Sqrt(
                            Math.Pow(
                                Math.Sin(originLatitude.DiffRadian(destinationLatitude) / 2.0), 2.0) +
                                (
                                    Math.Cos(originLatitude.ToRadian()) *
                                    Math.Cos(destinationLatitude.ToRadian()) *
                                    Math.Pow(
                                        Math.Sin(originLongitude.DiffRadian(destinationLongitude) / 2.0),2.0
                                    )
                                )
                        )
                    )
                ), decimalPlaces
            );
        }
    }
}