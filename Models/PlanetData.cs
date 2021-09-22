namespace gttgBackend.Models
{
    public class PlanetData
    {
        //why struct?

        private static int currentID = 0;

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

        public int PlanetDataID { get; }
        public Coordinate Coordinates {get;}
        public int Population { get; }
        public string Race { get; }
        public string PlanetName { get; }
        public string PlanetDescription { get; }

    }
}
