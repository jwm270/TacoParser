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

            // Take your line and use line.Split(',') to split it up into an array of strings, separated by the char ','
            var cells = line.Split(',');

            // If your array's Length is less than 3, something went wrong
            if (cells.Length < 3)
            {
                // Log error message and return null
                return null; 
            }

            if (!double.TryParse(cells[0], out double latitude))
            {
                logger.LogError($"Could not parse latitude: {cells[0]}");
                return null;
            }

            if (!double.TryParse(cells[1], out double longitude))
            {
                logger.LogError($"Could not parse longitude: {cells[1]}");
                return null;
            }
            
            var name = cells[2];

            var point = new Point()
            {
                Latitude = latitude,
                Longitude = longitude
            };

            var tacoBell = new TacoBell
            {
                Name = name,
                Location = point
            };
            return tacoBell;
        }
    }
}
