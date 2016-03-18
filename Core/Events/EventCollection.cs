using System;
using System.Collections;
using System.Collections.Generic;

namespace Core.Interfaces
{
	/// <summary>
	/// Implementacja interfejsu kolekcji jedynie na potrzeby obiekty typu IEvent
	/// Pokrywa standardowa funkcjonalność Kolekcji ale bierze pod uwage unikalny identyfikator Event 
	/// przy Contains event (umozliwiając pominięcie implementacji mechanizmu komparatora)
	/// </summary>
	public class EventCollection : ICollection<IEvent>
	{
		private IList<IEvent> events = new List<IEvent>();
		private bool isReadOnly = false;

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

		public void Add(IEvent item)
		{
			events.Add(item);
		}

		public void Clear()
		{
			events.Clear();
		}

		public bool Contains(IEvent item)
		{
			foreach (var ev in events)
			{
				if (ev.Guid == item.Guid)
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
			return events.Remove(item);
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