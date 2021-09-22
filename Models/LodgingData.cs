namespace gttgBackend.Models
{
    public class LodgingData
    {
        public LodgingData(int planetID,string name, string location, float price, int rating)
        {
            PlanetID = planetID;
            LodgingDataID = currentLodgingID;
            currentLodgingID++;
            Location = location;
            Price = price;
            Name = name;
            Rating = rating;
        }

        private static int currentLodgingID = 1;
        public int LodgingDataID { get; set; }
        public int PlanetID { get; set; }
        public string Location { get; set; }
        public float Price { get; set; }
        public string Name { get; set; }
        public int Rating { get; set; }
    }
}
