using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Core.Interfaces;
using DDay.iCal;

namespace Core.Events
{
	public class EventModel : Event
	{
		[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:G}")]
		public DateTime From
		{
			set { DTStart = new iCalDateTime(value); }
			get
			{
				if (DTStart != null)
				{
					return CreateDate(DTStart);

				}
				else
				{
					return new DateTime();
				}
			}
		}

		private DateTime CreateDate(IDateTime date)
		{
			DateTime result = new DateTime(date.Year, date.Month, date.Day, date.Hour, date.Minute, date.Second, date.Date.Kind);
			return result;
		}

		[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:G}")]
		public DateTime To
		{
			set { DTEnd = new iCalDateTime(value); }
			get
			{
				if (DTEnd != null)
				{
					return CreateDate(DTEnd);
				}
				else
				{
					return new DateTime();
				}
			}
		}

		public Alarm AlarmObj
		{
			get
			{
				if (Alarms.Count > 0)
				{
					
					return Alarms.First() as Alarm;
				}
				return new Alarm();
			}
			set
			{
				Alarms.Clear();
				Alarms.Add(value);
			}
		}

		public TimeSpan DurationObj
		{
			get
			{
				if (AlarmObj.Trigger != null && AlarmObj.Trigger.Duration != null)
				{
					return (TimeSpan) AlarmObj.Trigger.Duration;
				}
				else
				{
					return new TimeSpan(0);
				}
			}

			set
			{
				if (AlarmObj.Trigger == null)
				{
					AlarmObj.Trigger = new Trigger();
				}

				AlarmObj.Trigger.Duration = value;
			}

		}
	}
}