namespace gttgBackend.Models
{
    public struct PlanetData
    {


        private static int currentID = 0;

        public PlanetData(string planetName, string planetDescription, int population, string race, Coordinate cords)
        {
            Coordinates = cords;
            PlanetID = currentID;
            currentID++;
            Population = population;
            Race = race;
            PlanetName = planetName;
            PlanetDescription = planetDescription;
        }

        public int PlanetID { get; }
        public Coordinate Coordinates {get;}
        public int Population { get; }
        public string Race { get; }
        public string PlanetName { get; }
        public string PlanetDescription { get; }

    }
}
