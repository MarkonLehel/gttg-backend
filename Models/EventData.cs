using System;

namespace gttgBackend.Models
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

        //Unique ID
        public string EventName { get;}
        public string Location { get; }
        public float Price { get; }
        public DateTime Date { get; }

    }
}
