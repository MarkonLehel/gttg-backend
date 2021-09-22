using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gttgBackend.Models
{
    public struct TravelType
    {
        public TravelType(string name, float speed, float price)
        {
            Name = name;
            Speed = speed;
            Price = price;
        }

        public string Name { get; }
        
        public float Speed { get; }

        public float Price { get; }

    }
}
