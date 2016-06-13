using System;
using System.Linq;
using Core.Interfaces;
using DDay.iCal;
using DDay.iCal.Serialization;

namespace Core.Events
{
	public class Parser : IParser
	{
		public iCalendar calendar { get; private set; }

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

		
	}
}