using System;
using DDay.iCal;

namespace Core.Interfaces
{
    /// <summary>
    /// Interfejs służący do opisania czasu zdarzenia [od - do]
    /// </summary>
    public interface IDateRange
    {
        IDateTime From { get; set; }
        IDateTime To { get; set; }
       
        TimeSpan Duration { get; }
    }
}