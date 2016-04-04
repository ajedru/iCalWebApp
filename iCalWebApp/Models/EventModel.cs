using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using Core.Events;
using Core.Interfaces;

namespace iCalWebApp.Models
{
	/// <summary>
	/// Oddzielna klasa modelu na potrzeby Web, ażeby nie mieszać bazowej funkcjonalności Core
	/// z jej reprezentacją w postaci strony internetowej
	/// </summary>
	public class EventModel: IEvent
	{
		private Guid guid;

		public EventModel()
		{
			/*Title = Config.DefaultEventTitle;
			Comment = Config.DefaultEventComment;

			DateRange = new DateRange(DateTime.Now,  DateTime.Now);*/
			CreationDate = DateTime.Now;

			guid = Guid.NewGuid();
		}

		/// <summary>
		/// Tytuł biezącego event
		/// </summary>
		public string Title { get; set; }

		/// <summary>
		/// Komentarz do bieżącego eventa
		/// </summary>
		public string Comment { get; set; }

		/// <summary>
		/// Obiekt zakresu czasu trwania zdarzenia
		/// </summary>
		public DateRangeModel DateRangeModel { get; set; }

		/// <summary>
		/// Czas stworzenia eventu
		/// </summary>
		/// 
		[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}")]
		public DateTime CreationDate { get; set; }

		/// <summary>
		/// Unikalny identyfikator obiektu zdarzenia
		/// </summary>
		public Guid Guid
		{
			get { return guid; }
			set { guid = value; }
		}

		public IDateRange DateRange
		{
			get { return DateRangeModel; }

			set
			{
				DateRangeModel range = new DateRangeModel();
				range.From = value.From;
				range.To = value.To;

				DateRangeModel = range;
			}
		}

		/// <summary>
		/// Metoda konwertujaca model Web do funkcjonalnej klasy Event w Core
		/// </summary>
		/// <returns></returns>
		public Event ConvertToEvent()
		{
			return new Event(Title, Comment, DateRange, CreationDate, guid);
		}

	}
}