namespace LoggingKata
{
    /// <summary>
    /// Parses a POI file to locate all the Taco Bells
    /// </summary>
    public class TacoParser
    {
        readonly ILog logger = new TacoLogger();
        
        public ITrackable Parse(string line)
        {
            logger.LogInfo("Begin parsing");

            if (line == null)
                //log
                return null;

            var cells = line.Split(',');

            if (cells.Length < 3)
                //log
                return null;
            double latitude;
            double longitude;

            if (!double.TryParse(cells[0], out latitude) || !double.TryParse(cells[1], out longitude))
            {
                //log
                return null;
            }

            string locationName = cells[2].Trim();

            //catch invalid input

            if (latitude < -90 || latitude > 90 || longitude > 180 || locationName.ToLower()[0] != 't' || !locationName.ToLower().Contains("taco bell"))
                return null;
            //instantiate TacoBell and Point

            TacoBell tacobell = new TacoBell();
            Point point = new Point(latitude, longitude);

            //set Name and Location
            tacobell.Name = locationName;
            tacobell.Location = point;

            return tacobell;
            // Do not fail if one record parsing fails, return null
            return null; // TODO Implement
        }
    }
}