using System;
using System.Collections.Generic;

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
        public LodgingData? currentlySelectedLodging { 
            get { return currentlySelectedLodging; }
            set { currentlySelectedLodging = value; UpdateLodgingInfo(); }
        }
        public DateTime LodgingBookedFrom { 
            get { return LodgingBookedFrom; } 
            set { LodgingBookedFrom = LodgingBookedUntil < LodgingBookedFrom ? value : LodgingBookedFrom;
                UpdateLodgingPrice(); } 
        }
        public DateTime LodgingBookedUntil { 
            get { return LodgingBookedUntil; }
            set { LodgingBookedUntil = LodgingBookedUntil > LodgingBookedFrom ? value: LodgingBookedUntil; 
                UpdateLodgingPrice(); } 
        }

        public float LodgingPrice { get; private set; }
        #endregion

        #region Travel
        public float travelTime { get; private set; }
        public TravelType travelType { get; set; }

        

        #endregion
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
            }
        }

        public void AddEventToTrip(EventData eventToAdd) {
            attendedEvents.Add(eventToAdd);
            CalculateTotalEventPrice();
        }
        public void RemoveEventFromTrip(EventData eventToRemove) {
            attendedEvents.Remove(eventToRemove);
            CalculateTotalEventPrice();
        }
        private void CalculateTotalEventPrice()
        {
            float tempEventPrice = 0;
            foreach (EventData eventItem in attendedEvents)
            {
                tempEventPrice += eventItem.Price;
            }
            totalEventPrice = tempEventPrice;
        }

        private void UpdateLodgingInfo() {
            UpdateLodgingPrice();
        }
        private void UpdateLodgingPrice() {
            if (currentlySelectedLodging.HasValue) { 
                int durationInDays = (LodgingBookedUntil - LodgingBookedFrom).Days;
                LodgingPrice = currentlySelectedLodging.Value.Price * durationInDays;
            }
        }
    }
}
