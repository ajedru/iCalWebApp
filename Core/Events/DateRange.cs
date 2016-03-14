using System;
using Core.Interfaces;

namespace Core.Events
{
    public class DateRange : IDateRange
    {

        public DateRange( DateTime from, DateTime to)
        {
            From = from;
            To = to;
        }

        public DateTime From { get; set; }
        public DateTime To { get; set; }

        public TimeSpan Duration
        {
            get
            {
                TimeSpan difference = To - From;
                return difference;
            }
        }
    }
}
