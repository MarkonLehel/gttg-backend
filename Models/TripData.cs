using System;
using System.Collections.Generic;

namespace gttgBackend.Models
{
    public class TripData
    {
        #region PlanetData
        private PlanetData _startingPlanet = null;
        private PlanetData _destinationPlanet = null;
        public float DistanceBetweenDestinations { get; private set; }
        public PlanetData StartingPlanet { get { return _startingPlanet; }
            set {
                SetStartingPlanet(value);} }
        public PlanetData DestinationPlanet
        {
            get { return _destinationPlanet; }
            set
            {
                SetDestinationPlanet(value);
            }
        }
        #endregion

        #region TripEvents
        public List<EventData> attendedEvents { get; } = new List<EventData>();
        public float totalEventPrice { get; private set; }


        #endregion

        #region Lodging
        public LodgingData currentlySelectedLodging { 
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
        public TravelType? travelType { get { return travelType; }
            set { travelType = value; UpdateTravelData(); } }
        public float TotalTravelPrice { get; private set; }

        #endregion
        //Price calculation

        public void SetStartingPlanet(PlanetData planet) {
            _startingPlanet = planet;
            UpdateDistance();
            UpdateTravelData();
        }
        public void SetDestinationPlanet(PlanetData planet) {
            _destinationPlanet = planet;
            UpdateDistance();
            UpdateTravelData();
            currentlySelectedLodging = null;
            ResetEvents();

        }
        private void UpdateDistance()
        {
            if (_startingPlanet != null && _destinationPlanet != null)
            {
                DistanceBetweenDestinations = Coordinate.CalcDistance(_startingPlanet.Coordinates, _destinationPlanet.Coordinates); 
            } else
            {
                DistanceBetweenDestinations = 0;
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
        private void ResetEvents()
        {
            attendedEvents.Clear();
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
            if (currentlySelectedLodging != null) { 
                int durationInDays = (LodgingBookedUntil - LodgingBookedFrom).Days;
                LodgingPrice = currentlySelectedLodging.Price * durationInDays;
            } else
            {
                LodgingPrice = 0;
            }
        }

        private void UpdateTravelData()
        {
            if (travelType.HasValue && DistanceBetweenDestinations != 0)
            {
                travelTime = DistanceBetweenDestinations / travelType.Value.Price;
                TotalTravelPrice = DistanceBetweenDestinations * travelType.Value.Price;
            } else
            {
                travelTime = 0;
                TotalTravelPrice = 0;
            }
        }

        public float CalculateTotalTripPrice() {
            return LodgingPrice + totalEventPrice + TotalTravelPrice;
        }
    }

    
}
