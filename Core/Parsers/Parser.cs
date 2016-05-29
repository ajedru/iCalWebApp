using System;
using System.Linq;
using Core.Interfaces;
using DDay.iCal;
using DDay.iCal.Serialization;

namespace Core.Events
{
	public class Parser : IParser
	{
		private iCalendar calendar;

		public Parser()
		{
			calendar = new iCalendar();
			calendar.ProductID = "-//iCalWebbApp//PL";
			calendar.AddLocalTimeZone();
		}

		public iCalendar ParseToCalendar(string content)
		{
			IICalendarCollection calendarColl = iCalendar.LoadFromFile(content);
			return (iCalendar) calendarColl.First();
		}

		public string ParseToString()
		{
			ISerializationContext ctx = new SerializationContext();
			ISerializerFactory factory = new DDay.iCal.Serialization.iCalendar.SerializerFactory();
			// Get a serializer for our object
			IStringSerializer serializer = factory.Build(calendar.GetType(), ctx) as IStringSerializer;

			string output = serializer.SerializeToString(calendar);
			return output;
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

		private void CreateAndAddEvent(string summary, string description, DateTime start, DateTime end, Alarm alarm)
		{
			DDay.iCal.Event evt = calendar.Create<DDay.iCal.Event>();
			iCalDateTime today = iCalDateTime.Today;
			evt.Start = DateToiCalDate(start);
			evt.End = DateToiCalDate(end); // This also sets the duration
			evt.Description = description;
			evt.Summary = summary;
			if (alarm != null) evt.Alarms.Add(alarm);
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