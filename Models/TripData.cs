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

            StartingPlanet = (PlanetData)PlanetData.planetList.Where(planetToCheck => startingPlanet == planetToCheck.PlanetDataID).Single();
            DestinationPlanet = (PlanetData)PlanetData.planetList.Where(planetToCheck => destinationPlanet == planetToCheck.PlanetDataID).Single();
            CurrentlySelectedLodging = (LodgingData)LodgingData.lodgingList.Where(lodgingToCheck => currentlySelectedLodging == lodgingToCheck.LodgingDataID).Single();
            LodgingBookedFrom = DateTime.Parse(lodgingBookedFrom);
            LodgingBookedUntil = DateTime.Parse(lodgingBookedUntil);
            AttendedEvents = EventData.eventList.Where(eventToCheck => events.Contains(eventToCheck.EventDataID)).ToList();
            TravelType = (TravelType)TravelType.travelTypes.Where(travelTP => travelType == travelTP.TravelTypeID).Single();

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
        private LodgingData _currentlySelectedLodging;
        public LodgingData CurrentlySelectedLodging { 
            get => _currentlySelectedLodging;
            set { _currentlySelectedLodging = value; UpdateLodgingInfo(); }
        }
        private DateTime _lodgingBookedFrom;
        public DateTime LodgingBookedFrom {
            get => _lodgingBookedFrom; 
            set {
                _lodgingBookedFrom = value;
                UpdateLodgingPrice(); } 
        }
        private DateTime _lodgingBookedUntil;
        public DateTime LodgingBookedUntil {
            get => _lodgingBookedUntil;
            set {
                _lodgingBookedUntil = value;
                UpdateLodgingPrice(); } 
        }
        public float LodgingPrice { get; private set; }
        #endregion

        #region Travel
        public float TravelTime { get; private set; }
        private TravelType _travelType;
        public TravelType TravelType { get => _travelType; 
            set { _travelType = value; UpdateTravelData(); } }
        public float TotalTravelPrice { get; private set; }

        #endregion

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
    public override string ToString()
    {
            return $"{StartingPlanet},{DestinationPlanet}, {CurrentlySelectedLodging}, {LodgingBookedFrom}, {LodgingBookedUntil}, {TravelType}, {AttendedEvents.Count()}";
    }
    } 

}
