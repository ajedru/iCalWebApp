using System;

namespace Core.Interfaces
{
    /// <summary>
    /// Interfejs służący do opisania czasu zdarzenia [od - do]
    /// </summary>
    public interface IDateRange
    {
        DateTime From { get; set; }
        DateTime To { get; set; }
       
        TimeSpan Duration { get; }
    }
}