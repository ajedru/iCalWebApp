using System;
using Core.Interfaces;

namespace Core.Events
{
	/// <summary>
	/// Model wydarzenia
	/// </summary>
	public class Event : IEvent
	{
		private readonly Guid guid;

		public Event(string title, string comment, IDateRange dateRange, DateTime creationDate, Guid guid)
		{
			Title = title;
			Comment = comment;
			DateRange = dateRange;
			CreationDate = creationDate;
			this.guid = guid;
		}

		public string Title { get; set; }
		public string Comment { get; set; }

		public IDateRange DateRange { get; set; }

		public DateTime CreationDate { get; set; }

		public Guid Guid
		{
			get { return guid; }
		}
	}
}