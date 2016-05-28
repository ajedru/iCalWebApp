using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Interfaces;
using DDay.iCal;
using DDay.iCal.Serialization;
using System.IO;

namespace Core.Events
{
    class ParserToICal : IParserToICal
    {
        iCalendar CalendarFile;

        public ParserToICal()
        {
            CalendarFile = new iCalendar();
            CalendarFile.ProductID = "-//iCalWebbApp//PL";
            CalendarFile.AddLocalTimeZone();
            
        }

        public Alarm CreateAlarm(int days, int hours, int minutes, int seconds)
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

        public void CreateAndAddEvent(string summary, string description, DateTime start, DateTime end, Alarm alarm)
        {
            DDay.iCal.Event evt = CalendarFile.Create<DDay.iCal.Event>();
            iCalDateTime today = iCalDateTime.Today;
            evt.Start = DateToiCalDate(start);
            evt.End = DateToiCalDate(end); // This also sets the duration
            evt.Description = description;
            evt.Summary = summary;
            if(alarm != null) evt.Alarms.Add(alarm);
        }

        public IDateTime DateToiCalDate(DateTime date)
        {
            iCalDateTime today = iCalDateTime.Today;
            return today.AddYears(date.Year - today.Year)
                                    .AddMonths(date.Month - today.Month)
                                    .AddDays(date.Day - today.Day)
                                    .AddHours(date.Hour - today.Hour)
                                    .AddMinutes(date.Minute - today.Minute);
        }

        public string ParseToICalString()
        {
            ISerializationContext ctx = new SerializationContext();
            ISerializerFactory factory = new DDay.iCal.Serialization.iCalendar.SerializerFactory();
            // Get a serializer for our object
            IStringSerializer serializer = factory.Build(CalendarFile.GetType(), ctx) as IStringSerializer;

            string output = serializer.SerializeToString(CalendarFile);
            return output;
        }
    }
}
