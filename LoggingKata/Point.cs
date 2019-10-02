namespace LoggingKata
{
    public struct Point
    {
        public double Longitude { get; set; }
        public double Latitude { get; set; }

        public Point(double x, double y)
        {
          Latitude = x;
          Longitude = y;       
        }
    }
}