using System;
using Core.Interfaces;

namespace iCalWebApp.Models
{
	public class DateRangeModel : IDateRange
	{
		public DateTime From { get; set; }
		public DateTime To { get; set; }
		public TimeSpan Duration { get; }
	}
}