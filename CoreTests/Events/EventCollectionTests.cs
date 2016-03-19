using System;
using System.Collections;
using System.Linq;
using Core.Events;
using Core.Interfaces;
using NUnit.Framework;

namespace Core.Tests.Events
{
	[TestFixture]
	public class EventCollectionTests
	{
		[Test]
		public void EventCollectionContainsAddedObject()
		{
			//Arrange
			Guid guid = Guid.NewGuid();

			IEvent ev = new Event("Title", "Comment", new DateRange(DateTime.Now, DateTime.Now), DateTime.Now, Guid.Empty);
			IEvent ev2 = new Event("Title", "Comment", new DateRange(DateTime.Now, DateTime.Now), DateTime.Now, guid);
			EventCollection collection = new EventCollection();

			//Act
			collection.Add(ev);
			collection.Add(ev2);

			//Assert
			Assert.IsTrue(collection.Contains(ev2));
		}

		[Test]
		public void EventCollectionDoesNotContainsGivenItem()
		{
			//Arrange
			Guid guid = Guid.NewGuid();
			EventCollection collection = new EventCollection();

			//Act
			//Kolekcja jest pusta wiec nie trzeba nic robić

			//Assert
			Assert.IsFalse(collection.Contains(guid));
			
		}

		[Test]
		public void EventCollectionRemovedProperObject()
		{
			//Arrange
			Guid guid = Guid.NewGuid();

			IEvent ev = new Event("Title", "Comment", new DateRange(DateTime.Now, DateTime.Now), DateTime.Now, Guid.Empty);
			IEvent ev2 = new Event("Title 2", "Comment 2", new DateRange(DateTime.Now, DateTime.Now), DateTime.Now, guid);
			EventCollection collection = new EventCollection();

			//Act
			collection.Add(ev);
			collection.Add(ev2);

			collection.Remove(ev2);

			//Assert
			Assert.IsFalse(collection.Contains(guid));
		}

		[Test]
		public void EventCollectionDoesNotAllowDupeEvents()
		{
			//Arrange
			Guid guid = Guid.NewGuid();

			IEvent ev = new Event("Title", "Comment", new DateRange(DateTime.Now, DateTime.Now), DateTime.Now, guid);
			IEvent ev2 = new Event("Title", "Comment", new DateRange(DateTime.Now, DateTime.Now), DateTime.Now, guid);

			EventCollection collection = new EventCollection();

			//Act
			collection.Add(ev);
			collection.Add(ev2);

			//Assert
			Assert.AreEqual(1, collection.Count);
		}

		[TestCase("old", "old", "NEW", "NEW")]
		public void AddingExistingObjectInCollectionShouldUpdateIt(string evName, string evComment, string ev2Name, string ev2Comment)
		{
			//Arrange
			Guid guid = Guid.NewGuid();

			IEvent ev = new Event(evName, evComment, new DateRange(DateTime.Now, DateTime.Now), DateTime.Now, guid);
			IEvent ev2 = new Event(ev2Name, ev2Comment, new DateRange(DateTime.Now, DateTime.Now), DateTime.Now, guid);

			EventCollection collection = new EventCollection();

			//Act
			collection.Add(ev);
			collection.Add(ev2);

			IEvent updated = collection.Get(guid);

			//Assert
			Assert.AreEqual(new[] {ev2Name, ev2Comment}, new[] {updated.Title, updated.Comment});
		}

		[Test]
		public void ClearingCollectionShouldBeSuccessful()
		{
			//Arrange
			IEvent ev = new Event("Title", "Comment", new DateRange(DateTime.Now, DateTime.Now), DateTime.Now, Guid.NewGuid());
			IEvent ev2 = new Event("Title", "Comment", new DateRange(DateTime.Now, DateTime.Now), DateTime.Now, Guid.NewGuid());
			IEvent ev3 = new Event("Title", "Comment", new DateRange(DateTime.Now, DateTime.Now), DateTime.Now, Guid.NewGuid());

			EventCollection collection = new EventCollection();

			//Act
			collection.Add(ev);
			collection.Add(ev2);
			collection.Add(ev3);

			collection.Clear();

			//Assert
			Assert.AreEqual(0, collection.Count);
		}

		[Test]
		public void EventCollectionReturnsNullIfDoesntContainsGivenObject()
		{
			//Arrange
			IEvent ev = new Event("Title", "Comment", new DateRange(DateTime.Now, DateTime.Now), DateTime.Now, Guid.NewGuid());

			EventCollection collection = new EventCollection();

			//Act
			collection.Add(ev);

			//Assert
			Assert.IsNull(collection.Get(Guid.NewGuid()));
		}

		[Test]
		public void EventCollectionReturnsProperItemsInForEachLoop()
		{
			Guid[] guids = { Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid() };
			//Arrange
			IEvent ev = new Event("Title", "Comment", new DateRange(DateTime.Now, DateTime.Now), DateTime.Now, guids[0]);
			IEvent ev2 = new Event("Title", "Comment", new DateRange(DateTime.Now, DateTime.Now), DateTime.Now, guids[1]);
			IEvent ev3 = new Event("Title", "Comment", new DateRange(DateTime.Now, DateTime.Now), DateTime.Now, guids[2]);

			EventCollection collection = new EventCollection();

			//Act
			collection.Add(ev);
			collection.Add(ev2);
			collection.Add(ev3);

			bool succeed = true;

			foreach (IEvent item in collection)
			{
				if (!guids.Contains(item.Guid))
				{
					succeed = false;
				}
			}

			//Assert
			Assert.IsTrue(succeed);
		}

		[Test]
		public void EventCollectionCopiesUniqueObjectToArray()
		{
			//Arrange
			IEvent[] events = new IEvent[2];
			Guid guid = Guid.NewGuid();

			IEvent ev0 = new Event("Title", "Comment", new DateRange(DateTime.Now, DateTime.Now), DateTime.Now, guid);
			IEvent ev1 = new Event("Title", "Comment", new DateRange(DateTime.Now, DateTime.Now), DateTime.Now, guid);

			EventCollection collection = new EventCollection();

			//Act
			collection.Add(ev0);
			collection.Add(ev1);

			collection.CopyTo(events, 0);

			var count = CountItems(events);

			//Assert
			Assert.AreEqual(1, count);
		}

		[Test]
		public void EventCollectionReturnsProperCountOfItems()
		{
			Guid[] guids = { Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid() };
			//Arrange
			IEvent ev = new Event("Title", "Comment", new DateRange(DateTime.Now, DateTime.Now), DateTime.Now, guids[0]);
			IEvent ev2 = new Event("Title", "Comment", new DateRange(DateTime.Now, DateTime.Now), DateTime.Now, guids[1]);
			IEvent ev3 = new Event("Title", "Comment", new DateRange(DateTime.Now, DateTime.Now), DateTime.Now, guids[2]);

			EventCollection collection = new EventCollection();

			//Act
			collection.Add(ev);
			collection.Add(ev2);
			collection.Add(ev3);

			//Assert
			Assert.AreEqual(CountItems(collection), collection.Count);
		}

		private static int CountItems(IEnumerable items)
		{
			int count = 0;
			foreach (var item in items)
			{
				if (item != null)
				{
					count++;
				}
			}
			return count;
		}
	}
}
