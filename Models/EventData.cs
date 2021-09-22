using System;

namespace gttgBackend.Models
{
    public class EventData
    {
        public EventData(string eventName, string location, float price, DateTime date)
        {
            EventDataID = currentEventID;
            currentEventID++;
            EventName = eventName;
            Location = location;
            Price = price;
            Date = date;
        }

        private static int currentEventID = 1;

        public int EventDataID { get; set; }
        public string EventName { get; set; }
        public string Location { get; set; }
        public float Price { get; set; }
        public DateTime Date { get; set; }

    }
}
