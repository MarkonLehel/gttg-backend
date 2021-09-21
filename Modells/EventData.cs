using System;

namespace gttgBackend.Modells
{
    public struct EventData
    {
        public EventData(string eventName, string location, float price, DateTime date)
        {
            EventName = eventName;
            Location = location;
            Price = price;
            Date = date;
        }

        public string EventName { get;}
        public string Location { get; }
        public float Price { get; }
        public DateTime Date { get; }

    }
}
