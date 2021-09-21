using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gttgBackend.Modells
{
    public class TripData
    {

        private PlanetData? _startingPlanet = null;
        private PlanetData? _destinationPlanet = null;
        public double DistanceBetweenDestinations { get; private set; }
        public PlanetData StartingPlanet { get { return _startingPlanet.Value; }
            set {
                SetStartingPlanet(value);} }
        public PlanetData DestinationPlanet
        {
            get { return _destinationPlanet.Value; }
            set
            {
                SetDestinationPlanet(value);
            }
        }


        public void SetStartingPlanet(PlanetData planet) {
            _startingPlanet = planet;
            UpdateDistance();
        }
        public void SetDestinationPlanet(PlanetData planet) {
            _destinationPlanet = planet;
            UpdateDistance();

        }
        private void UpdateDistance()
        {
            if (_startingPlanet.HasValue && _destinationPlanet.HasValue)
            {
                DistanceBetweenDestinations = Coordinate.CalcDistance(_startingPlanet.Value.Coordinates, _destinationPlanet.Value.Coordinates); 
            }
        }
        
    }
}
