namespace gttgBackend.Models
{
    public class PlanetData
    {
        public PlanetData(string planetName, string planetDescription, int population, string race, int x,int y)
        {
            X = x;
            Y = y;
            PlanetDataID = currentID;
            currentID++;
            Population = population;
            Race = race;
            PlanetName = planetName;
            PlanetDescription = planetDescription;
        }

        private static int currentID = 1;
        public int PlanetDataID { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int Population { get; set; }
        public string Race { get; set; }
        public string PlanetName { get; set; }
        public string PlanetDescription { get; set; }

    }
}
