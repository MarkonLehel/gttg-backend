using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gttgBackend.Modells
{
    public class TripData
    {
        #region PlanetData
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
        #endregion

        #region TripEvents
        public List<EventData> attendedEvents { get; } = new List<EventData>();
        public double totalEventPrice { get; private set; }


        #endregion
        #region Lodging
        public LodgingData currentlySelectedLodging { get; set; }
        public DateTime LodgingBookedFrom { get; set; }
        public DateTime LodgingBookedUntil { get; set; }
        #endregion
        //Lodging
        //Travel
        //Price calculation

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
            } else
            {
                DistanceBetweenDestinations = 0;
            }
        }
        
    }
}
