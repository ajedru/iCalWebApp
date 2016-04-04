using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Core.Events;
using Core.Interfaces;

namespace iCalWebApp.Models
{
	public class EventCollectionModel : EventCollection,IEnumerable<EventModel>
	{
		public new IEnumerator<EventModel> GetEnumerator()
		{
			foreach (var item in events)
			{
				yield return RemapEvent(item);
			}
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		public new EventModel Get(Guid guid)
		{
			IEvent found = base.Get(guid);
			return RemapEvent(found);
		}

		private EventModel RemapEvent(IEvent ev)
		{
			EventModel model = ev as EventModel;
			if (model == null)
			{
				model = new EventModel();
				model.DateRange = ev.DateRange;
				model.Title = ev.Title;
				model.Comment = ev.Comment;
			}

			return model;
		}
	}
}