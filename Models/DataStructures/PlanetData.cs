using System.Collections.Generic;

namespace gttgBackend.Models
{
    public class PlanetData
    {
        public static List<PlanetData> planetList = new();
        public PlanetData(string planetName, string planetDescription, int population, string race, string imageName, int x,int y)
        {
            X = x;
            Y = y;
            PlanetDataID = currentID;
            currentID++;
            Population = population;
            Race = race;
            PlanetName = planetName;
            PlanetDescription = planetDescription;
            planetList.Add(this);
            ImageName= imageName;
        }

        private static int currentID = 1;
        public int PlanetDataID { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public string ImageName { get; set; }
        public int Population { get; set; }
        public string Race { get; set; }
        public string PlanetName { get; set; }
        public string PlanetDescription { get; set; }

        public override string ToString()
        {
            return "Planet: " + PlanetName + " " + PlanetDataID + " " + PlanetDescription;
        }
    }
}
