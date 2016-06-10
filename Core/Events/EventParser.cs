using System;
using Core.Interfaces;
using DDay.iCal;

namespace Core.Events
{				  
	/*public class EventParser : Event
	{	
		public static DDay.iCal.IEvent ParseToEvent(Core.Interfaces.IEvent @event)
		{
			DDay.iCal.IEvent result = new DDay.iCal.Event();

			result.Start = @event.DateRange.From; 
			result.End = @event.DateRange.To;
			result.Name = @event.Title;
			result.Description = @event.Comment;

			return result;
		}

		public static Core.Interfaces.IEvent ParseToModel(DDay.iCal.IEvent @event)
		{
			Core.Interfaces.IEvent result = new Core.Events.Event();

			result.DateRange.From = @event.Start;
			result.DateRange.To = @event.End;
			result.Title = @event.Name;
			result.Comment = @event.Description;

			return result;
		}
	}*/
}