using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gttgBackend.Models
{
    public struct PlanetData
    {
        public int PlanetID { get; }
        public string PlanetName { get; set; }
        public string PlanetDescription { get; set; }
        public List<LodgingData> Lodgings { get; }


    }
}
