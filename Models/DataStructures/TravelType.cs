using System.Collections.Generic;

namespace gttgBackend.Models
{
    public class TravelType
    {
        public static List<TravelType> travelTypes = new();
        public TravelType(string name, float speed, float price)
        {
            TravelTypeID = currentID;
            currentID++;

            Name = name;
            Speed = speed;
            Price = price;
            travelTypes.Add(this);
        }

        private static int currentID = 1;
        public int TravelTypeID { get; set; }
        public string Name { get; set; }
        
        public float Speed { get; set; }

        public float Price { get; set; }

    }
}
