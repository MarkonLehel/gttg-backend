namespace gttgBackend.Models
{
    public struct LodgingData
    {
        public LodgingData(string name, string location, float price, int rating)
        {
            LodgingID = currentLodgingID;
            currentLodgingID++;
            Location = location;
            Price = price;
            Name = name;
            Rating = rating;
        }

        private static int currentLodgingID = 1;
        public int LodgingID { get; }
        public string Location { get; }
        public float Price { get; }
        public string Name { get; }
        public int Rating { get; }
    }
}
