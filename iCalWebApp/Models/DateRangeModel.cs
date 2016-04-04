using System;
using System.ComponentModel.DataAnnotations;
using Core.Interfaces;

namespace iCalWebApp.Models
{
	public class DateRangeModel : IDateRange
	{
		private DateTime from;

		//[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}")]
		public DateTime From
		{
			get { return from; }
			set { from = value; }
		}

		//[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}")]
		public DateTime To { get; set; }

		//[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}")]
		public TimeSpan Duration { get; }
	}
}