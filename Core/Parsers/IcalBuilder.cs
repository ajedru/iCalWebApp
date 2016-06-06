using Core.Interfaces;
using DDay.iCal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Parsers
{
    class IcalBuilder : IIcalBuilder
    {
        public DDay.iCal.Event CreateEvent(string summary, string description, DateTime start, DateTime end, Alarm alarm)
        {
            DDay.iCal.Event evt = new DDay.iCal.Event();
            iCalDateTime today = iCalDateTime.Today;
            evt.Start = DateToiCalDate(start);
            evt.End = DateToiCalDate(end); // This also sets the duration
            evt.Description = description;
            evt.Summary = summary;
            if (alarm != null) evt.Alarms.Add(alarm);
            return evt;
        }

        public void AddEventToCalendar(iCalendar calendar, DDay.iCal.Event cacheEvent)
        {
            calendar.Events.Add(cacheEvent);
        }

        private Alarm CreateAlarm(int days, int hours, int minutes, int seconds)
        {
            if (days == 0 & hours == 0 & minutes == 0 & seconds == 0)
                return null;
            else
            {
                Alarm alarm = new Alarm();
                alarm.Trigger = new Trigger(new TimeSpan(-days, -hours, -minutes, -seconds));
                alarm.Action = AlarmAction.Display;
                return alarm;
            }
        }

        private IDateTime DateToiCalDate(DateTime date)
        {
            iCalDateTime today = iCalDateTime.Today;
            return today.AddYears(date.Year - today.Year)
                .AddMonths(date.Month - today.Month)
                .AddDays(date.Day - today.Day)
                .AddHours(date.Hour - today.Hour)
                .AddMinutes(date.Minute - today.Minute);
        }

    }
}
