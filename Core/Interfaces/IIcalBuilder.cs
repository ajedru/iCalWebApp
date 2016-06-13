using DDay.iCal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    interface IIcalBuilder
    {
        DDay.iCal.Event CreateEvent(string summary, string description, DateTime start, DateTime end, Alarm alarm);
        void AddEventToCalendar(iCalendar calendar, DDay.iCal.Event cacheEvent);
        Alarm CreateAlarm(int days, int hours, int minutes, int seconds);
    }
}
