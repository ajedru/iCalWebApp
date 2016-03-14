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

        IDateRange DateRange { get; set; }

        DateTime CreationDate { get; set; }
    }
}