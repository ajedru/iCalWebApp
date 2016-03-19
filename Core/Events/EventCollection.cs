using System;
using System.Collections;
using System.Collections.Generic;
using Core.Interfaces;

namespace Core.Events
{
	/// <summary>
	/// Implementacja interfejsu kolekcji jedynie na potrzeby obiekty typu IEvent
	/// Pokrywa standardowa funkcjonalność Kolekcji ale bierze pod uwage unikalny identyfikator Event 
	/// przy Contains event (umozliwiając pominięcie implementacji mechanizmu komparatora)
	/// </summary>
	public class EventCollection : ICollection<IEvent>
	{
		private HashSet<IEvent> events = new HashSet<IEvent>();
		private bool isReadOnly;

		public EventCollection()
		{
			isReadOnly = false;
		}

		public IEnumerator<IEvent> GetEnumerator()
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

		public IEvent Get(Guid guid)
		{
			foreach (var ev in events)
			{
				if (ev.Guid == guid)
				{
					return ev;
				}
			}

			return null;
		}

		public void Add(IEvent item)
		{
			if (Contains(item.Guid))
			{
				Remove(item);
				
			}
			
			events.Add(item);
		}

		public void Clear()
		{
			events.Clear();
		}

		public bool Contains(IEvent item)
		{
			return Contains(item.Guid);
		}

		public bool Contains(Guid guid)
		{
			foreach (var ev in events)
			{
				if (ev.Guid == guid)
				{
					return true;
				}
			}
			return false;
		}

		public void CopyTo(IEvent[] array, int arrayIndex)
		{
			events.CopyTo(array, arrayIndex);
		}

		public bool Remove(IEvent item)
		{
			int succeed = events.RemoveWhere(ev => ev.Guid == item.Guid);

			return succeed > 0;
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