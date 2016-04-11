using System;
using Core.Interfaces;

namespace Core.Events
{
	/// <summary>
	/// Model wydarzenia
	/// </summary>
	public class Event : IEvent
	{
        /// <summary>
        /// Wewnętrzne pole tylko do odczytu dla właściwości Guid (unikalny numer eventu)
        /// </summary>
		private readonly Guid guid;

        /// <summary>
        /// Konstruktor ustawiający tytuł, opis, czas trwania, czas utworzenia, unikalny numer wydarzenia.
        /// </summary>
        /// <param name="title">tytuł</param>
        /// <param name="comment">opis</param>
        /// <param name="dateRange">czas trwania</param>
        /// <param name="creationDate">czas utworzenia</param>
        /// <param name="guid">unikalny numer</param>
		public Event(string title, string comment, IDateRange dateRange, DateTime creationDate, Guid guid)
		{
			Title = title;
			Comment = comment;
			DateRange = dateRange;
			CreationDate = creationDate;
			this.guid = guid;
		}

        /// <summary>
        /// Konstruktor ustawiający tytuł, opis, czas trwania, czas utworzenia, unikalny numer i alarm dla wydarzenia.
        /// </summary>
        /// <param name="title">tytuł</param>
        /// <param name="comment">opis</param>
        /// <param name="dateRange">czas trwania</param>
        /// <param name="creationDate"> czas utworzenia</param>
        /// <param name="guid">unikalny numer</param>
        /// <param name="alarmTime">alarm wykonujący się podaną liczbę minut przed zakończeniem wydarzenia</param>
        public Event(string title, string comment, IDateRange dateRange, DateTime creationDate, Guid guid, int alarmTime)
            : this(title, comment, dateRange, creationDate, guid)
        { 
            AlarmTime = alarmTime;
        }
        // Tomasz Papaj, konstruktor z alarmem

        public string Title { get; set; }

		public string Comment { get; set; }

        public int AlarmTime { get; set; } // Tomasz Papaj, Alarm eventu w minutach

		public IDateRange DateRange { get; set; }

		public DateTime CreationDate { get; set; }

		public Guid Guid
		{
			get { return guid; }
		}

        public Boolean HasAlarm()
        {
            if (AlarmTime > 0) return true;
            else return false;
        }
        //Tomasz Papaj, metoda sprawdzajaca obecnosc alarmu
	}
}