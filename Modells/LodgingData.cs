namespace gttgBackend.Modells
{
    public struct LodgingData
    {
        public LodgingData(string name, string location, float price, int rating)
        {
            Location = location;
            Price = price;
            Name = name;
            Rating = rating;
        }

        //Unique ID
        public string Location { get; }
        public float Price { get; }
        public string Name { get; }
        public int Rating { get; }
    }
}
