namespace gttgBackend.Models
{
    public class PlanetData
    {
        private static int currentID = 1;
        public int PlanetDataID { get; set; }

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

        public Coordinate Coordinates {get;}
        public int Population { get; }
        public string Race { get; }
        public string PlanetName { get; }
        public string PlanetDescription { get; }

    }
}
