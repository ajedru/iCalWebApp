using System;
using Core.Interfaces;

namespace iCalWebApp.Models
{
    public class EventModel : IEvent
    {
        public string Title { get; set; }
        public string Comment { get; set; }

        public IDateRange DateRange { get; set; }

        public DateTime CreationDate { get; set; }
    }
}