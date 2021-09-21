using System;

namespace gttgBackend.Modells
{
    public struct EventData
    {
        public EventData(string eventName, string location, float price, DateTime date)
        {
            EventID = currentEventID;
            currentEventID++;
            EventName = eventName;
            Location = location;
            Price = price;
            Date = date;
        }

        private static int currentEventID = 0;

        public int EventID { get; }
        public string EventName { get;}
        public string Location { get; }
        public float Price { get; }
        public DateTime Date { get; }

    }
}
