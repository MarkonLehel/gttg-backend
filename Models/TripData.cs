using System;
using System.Collections.Generic;
using System.Linq;

namespace gttgBackend.Models
{
    public class TripData
    {
        private static int currentTripID = 0;

        public int TripDataID { get; set; }
        public TripData()
        {
            TripDataID = currentTripID;
            currentTripID++;
        }

        public TripData(int startingPlanet, int destinationPlanet, int currentlySelectedLodging,string lodgingBookedFrom, string lodgingBookedUntil, int travelType, List<int> events)
        {
            TripDataID = currentTripID;
            currentTripID++;

            StartingPlanet = (PlanetData)PlanetData.planetList.Where(planetToCheck => startingPlanet == planetToCheck.PlanetDataID);
            DestinationPlanet = (PlanetData)PlanetData.planetList.Where(planetToCheck => destinationPlanet == planetToCheck.PlanetDataID);
            CurrentlySelectedLodging = (LodgingData)LodgingData.lodgingList.Where(lodgingToCheck => currentlySelectedLodging == lodgingToCheck.LodgingDataID);
            LodgingBookedFrom = DateTime.Parse(lodgingBookedFrom);
            LodgingBookedUntil = DateTime.Parse(lodgingBookedUntil);
            AttendedEvents = EventData.eventList.Where(eventToCheck => events.Contains(eventToCheck.EventDataID)).ToList();
            TravelType = (TravelType)TravelType.travelTypes.Where(travelTP => travelType == travelTP.TravelTypeID); ;

            Init();
        }

        private void Init()
        {
            UpdateDistance();
            CalculateTotalEventPrice();
            UpdateLodgingInfo();
            UpdateTravelData();
        }



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
        public List<EventData> AttendedEvents { get; } = new List<EventData>();
        public float TotalEventPrice { get; private set; }


        #endregion

        #region Lodging
        public LodgingData CurrentlySelectedLodging { 
            get { return CurrentlySelectedLodging; }
            set { UpdateLodgingInfo(); }
        }
        public DateTime LodgingBookedFrom { 
            get { return LodgingBookedFrom; } 
            set { 
                UpdateLodgingPrice(); } 
        }
        public DateTime LodgingBookedUntil { 
            get { return LodgingBookedUntil; }
            set {  
                UpdateLodgingPrice(); } 
        }
        public float LodgingPrice { get; private set; }
        #endregion

        #region Travel
        public float TravelTime { get; private set; }
        public TravelType TravelType { get { return TravelType; }
            set { UpdateTravelData(); } }
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
            CurrentlySelectedLodging = null;
            ResetEvents();

        }
        private void UpdateDistance()
        {
            if (_startingPlanet != null && _destinationPlanet != null)
            {
                DistanceBetweenDestinations = Coordinate.CalcDistance(_startingPlanet.X, _startingPlanet.Y, _destinationPlanet.X, _destinationPlanet.Y); 
            } else
            {
                DistanceBetweenDestinations = 0;
            }
        }

        public void AddEventToTrip(EventData eventToAdd) {
            AttendedEvents.Add(eventToAdd);
            CalculateTotalEventPrice();
        }
        public void RemoveEventFromTrip(EventData eventToRemove) {
            AttendedEvents.Remove(eventToRemove);
            CalculateTotalEventPrice();
        }
        private void ResetEvents()
        {
            AttendedEvents.Clear();
            CalculateTotalEventPrice();
        }
        private void CalculateTotalEventPrice()
        {
            float tempEventPrice = 0;
            foreach (EventData eventItem in AttendedEvents)
            {
                tempEventPrice += eventItem.Price;
            }
            TotalEventPrice = tempEventPrice;
        }

        private void UpdateLodgingInfo() {
            UpdateLodgingPrice();
        }
        private void UpdateLodgingPrice() {
            if (CurrentlySelectedLodging != null) { 
                int durationInDays = (LodgingBookedUntil - LodgingBookedFrom).Days;
                LodgingPrice = CurrentlySelectedLodging.Price * durationInDays;
            } else
            {
                LodgingPrice = 0;
            }
        }

        private void UpdateTravelData()
        {
            if (TravelType != null && DistanceBetweenDestinations != 0)
            {
                TravelTime = DistanceBetweenDestinations / TravelType.Price;
                TotalTravelPrice = DistanceBetweenDestinations * TravelType.Price;
            } else
            {
                TravelTime = 0;
                TotalTravelPrice = 0;
            }
        }

        public float CalculateTotalTripPrice() {
            return LodgingPrice + TotalEventPrice + TotalTravelPrice;
        }
    }

    
}
