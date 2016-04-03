using System;
using Core.Events;

namespace iCalWebApp.Models
{
	/// <summary>
	/// Oddzielna klasa modelu na potrzeby Web, ażeby nie mieszać bazowej funkcjonalności Core
	/// z jej reprezentacją w postaci strony internetowej
	/// </summary>
	public class EventModel //: IEvent
	{
		private readonly Guid guid = Guid.NewGuid();

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
		public DateRangeModel DateRange { get; set; }

		/// <summary>
		/// Czas stworzenia eventu
		/// </summary>
		public DateTime CreationDate { get; set; }

		/// <summary>
		/// Unikalny identyfikator obiektu zdarzenia
		/// </summary>
		public Guid Guid
		{
			get { return guid; }
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