using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web.Mvc;
using Core.Interfaces;
using DDay.iCal;

namespace Core.Events
{
	public class EventModel : Event
	{

		public EventModel() { }

		public EventModel(IEvent @event)
		{
			Start = @event.Start;
			End = @event.End;
			Alarms.Clear();
			Alarms.Add(@event.Alarms.FirstOrDefault());
			Summary = @event.Summary;
			Description = @event.Description;
			IsAllDay = @event.IsAllDay;
			UID = Guid.NewGuid().ToString();
		}

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

		/// <summary>
		/// WIP wciaz nie dziala
		/// </summary>
		/*private IEnumerable<FrequencyType> availableFrequency = new[]
		{
			FrequencyType.Daily,
			FrequencyType.Weekly,
			FrequencyType.Monthly,
			FrequencyType.Yearly
		};

		public IEnumerable<FrequencyType> AvailableFrequency
		{
			get { return availableFrequency; }
			set { return; }
		}

		public IEnumerable<FrequencyType> SelectedFrequency { get; set; }*/

		/// <summary>
		/// WIP wciaż nie działa
		/// </summary>
		/// <param name="date"></param>
		/// <returns></returns>
		/*public IEnumerable<FrequencyType> Recurrence
		{
			get
			{
				if (RecurrenceRules == null)
				{
					return new FrequencyType[0];
				}

				List<FrequencyType> freq = new List<FrequencyType>();
				foreach (var pattern in RecurrenceRules)
				{
					freq.Add(pattern.Frequency);
				}

				return freq;
			}
			set
			{
				if (RecurrenceRules == null)
				{
					RecurrenceRules = new List<IRecurrencePattern>();
				}

				foreach (var freq in value)
				{
					RecurrenceRules.Clear();
					RecurrenceRules.Add(new RecurrencePattern(freq));
				}
			}
		}*/
		
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

		[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:G}")]
		public DateTime CreatedObj
		{
			set { Created = new iCalDateTime(value); }
			get
			{
				if (Created != null)
				{
					return CreateDate(Created);
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


		public DateTime DateFromTimeSpan(TimeSpan span)
		{
			return From - span;
		}

		public TimeSpan DateToTimeSpan(DateTime date)
		{
			return From - date;
		}

		

		public Nullable<DateTime> DurationObj
		{
			get
			{
				if (AlarmObj.Trigger != null && AlarmObj.Trigger.Duration != null)
				{
					return DateFromTimeSpan((TimeSpan) AlarmObj.Trigger.Duration);
				}
				else
				{
					return new DateTime();
				}
			}

			set
			{
				if (value == DateTime.MinValue || value == null)
				{
					return;
				}

				if (AlarmObj.Trigger == null)
				{
					AlarmObj.Trigger = new Trigger();
				}

				AlarmObj.Trigger.Duration = DateToTimeSpan((DateTime)value);
			}

		}

	
	}
}