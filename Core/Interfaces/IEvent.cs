using System;

namespace Core.Interfaces
{
	/// <summary>
	/// Iterfejs służący do opisu zdarzenia.
	/// </summary>
	public interface IEvent
	{
		string Title { get; set; }
		string Comment { get; set; }
        int AlarmTime { get; set; } // Tomasz Papaj, Alarm eventu w minutach

        IDateRange DateRange { get; set; }

		DateTime CreationDate { get; set; }
		Guid Guid { get; }
        Boolean HasAlarm(); // Tomasz Papaj, metoda sprawdzajaca obecnosc alarmu
    }
}