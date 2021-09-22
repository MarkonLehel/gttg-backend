namespace gttgBackend.Models
{
    public class PlanetData
    {
        private static int currentID = 1;
        public int PlanetDataID { get; set; }

        public PlanetData()
        {
            PlanetDataID = currentID;
            currentID++;
        }

        public PlanetData(string planetName, string planetDescription, int population, string race, Coordinate cords)
        {
            Coordinates = cords;
            PlanetDataID = currentID;
            currentID++;
            Population = population;
            Race = race;
            PlanetName = planetName;
            PlanetDescription = planetDescription;
        }

        
        public Coordinate Coordinates { get; set; }
        public int Population { get; set; }
        public string Race { get; set;  }
        public string PlanetName { get; set; }
        public string PlanetDescription { get; set; }

    }
}
