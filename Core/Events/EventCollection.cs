using System;
using System.Collections;
using System.Collections.Generic;
using DDay.iCal;

namespace Core.Events
{
	/// <summary>
	/// Implementacja interfejsu kolekcji jedynie na potrzeby obiekty typu IEvent
	/// Pokrywa standardowa funkcjonalność Kolekcji ale bierze pod uwage unikalny identyfikator Event 
	/// przy Contains event (umozliwiając pominięcie implementacji mechanizmu komparatora)
	/// </summary>
	public class EventCollection : ICollection<EventModel>
	{
		protected HashSet<EventModel> events = new HashSet<EventModel>();
		private bool isReadOnly;
        private ICollection<IEvent> events1;

        public TimeZoneInfo TimeZone { get; private set; }

		public EventCollection()
		{
			isReadOnly = false;
			TimeZone = TimeZoneInfo.Utc;
		}

		public EventCollection(TimeZoneInfo timeZone)
		{
			TimeZone = timeZone;
		}

        public EventCollection(ICollection<IEvent> events)
        {
            foreach (var @event in events)
            {
	            this.events.Add(new EventModel(@event));
            }
                 
        }

        public IEnumerator<EventModel> GetEnumerator()
		{
			foreach (var item in events)
			{
				yield return item;
			}
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		public EventModel Get(string guid)
		{
			foreach (var ev in events)
			{
				if (ev.UID == guid)
				{
					return ev;
				}
			}

			return null;
		}

		public void Add(EventModel item)
		{
			if (Contains(item.UID))
			{
				Remove(item);
				
			}
			
			events.Add(item);
		}

		public void Clear()
		{
			events.Clear();
		}

		public bool Contains(EventModel item)
		{
			return Contains(item.UID);
		}

		public bool Contains(string guid)
		{
			foreach (var ev in events)
			{
				if (ev.UID == guid)
				{
					return true;
				}
			}
			return false;
		}

		public void CopyTo(EventModel[] array, int arrayIndex)
		{
			events.CopyTo(array, arrayIndex);
		}

		public bool Remove(EventModel item)
		{
			int succeed = events.RemoveWhere(ev => ev.UID == item.UID);

			return succeed > 0;
		}

		public bool Remove(string id)
		{
			EventModel ev = Get(id);
			if (ev == null)
			{
				return false;
			}

			return Remove(ev);
		}

		public int Count
		{
			get { return events.Count; }
		}

		public bool IsReadOnly
		{
			get { return isReadOnly; }
		}
	}
}