using System;
using Core.Interfaces;
using DDay.iCal;

namespace Core.Events
{
	public class DateRange : IDateRange
	{

		public DateRange(IDateTime from, IDateTime to)
		{
			From = from;
			To = to;
		}

		public IDateTime From { get; set; }
		public IDateTime To { get; set; }

		public TimeSpan Duration
		{
			get
			{
				TimeSpan difference = To.Subtract(From);
				return difference;
			}
		}
	}
}
