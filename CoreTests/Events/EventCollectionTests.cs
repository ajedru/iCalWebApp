using System;
using System.Collections;
using System.Linq;
using Core.Events;
using Core.Interfaces;
using DDay.iCal;
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

			EventModel ev = new EventModel();
			ev.Summary = "Title";
			ev.Description = "Comment";
			ev.Start = new iCalDateTime(DateTime.Now);
			ev.End =  new iCalDateTime(DateTime.Now);

			EventModel ev2 = new EventModel();
			ev2.Summary = "Title";
			ev2.Description = "Comment";
			ev2.Start = new iCalDateTime(DateTime.Now);
			ev2.End = new iCalDateTime(DateTime.Now);

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
			string guid = Guid.NewGuid().ToString();
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
			string guid = Guid.NewGuid().ToString();

			EventModel ev = new EventModel();
			ev.Summary = "Title";
			ev.Description = "Comment";
			ev.Start = new iCalDateTime(DateTime.Now);
			ev.End = new iCalDateTime(DateTime.Now);

			EventModel ev2 = new EventModel();
			ev2.Summary = "Title 2";
			ev2.Description = "Comment 2";
			ev2.Start = new iCalDateTime(DateTime.Now);
			ev2.End = new iCalDateTime(DateTime.Now);

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
			string guid = Guid.NewGuid().ToString();

			EventModel ev = new EventModel();
			ev.Summary = "Title";
			ev.Description = "Comment";
			ev.Start = new iCalDateTime(DateTime.Now);
			ev.End = new iCalDateTime(DateTime.Now);
			ev.UID = guid;

			EventModel ev2 = new EventModel();
			ev2.Summary = "Title 2";
			ev2.Description = "Comment 2";
			ev2.Start = new iCalDateTime(DateTime.Now);
			ev2.End = new iCalDateTime(DateTime.Now);
			ev2.UID = guid;

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
			string guid = Guid.NewGuid().ToString();

			EventModel ev = new EventModel();
			ev.Summary = evName;
			ev.Description = evComment;
			ev.Start = new iCalDateTime(DateTime.Now);
			ev.End = new iCalDateTime(DateTime.Now);
			ev.UID = guid;

			EventModel ev2 = new EventModel();
			ev2.Summary = ev2Name;
			ev2.Description = ev2Comment;
			ev2.Start = new iCalDateTime(DateTime.Now);
			ev2.End = new iCalDateTime(DateTime.Now);
			ev2.UID = guid;

			EventCollection collection = new EventCollection();

			//Act
			collection.Add(ev);
			collection.Add(ev2);

			IEvent updated = collection.Get(guid);

			//Assert
			Assert.AreEqual(new[] {ev2Name, ev2Comment}, new[] {updated.Summary, updated.Description});
		}

		[Test]
		public void ClearingCollectionShouldBeSuccessful()
		{
			//Arrange

			EventModel ev = new EventModel();
			ev.Summary = "Title";
			ev.Description = "Comment";
			ev.Start = new iCalDateTime(DateTime.Now);
			ev.End = new iCalDateTime(DateTime.Now);

			EventModel ev2 = new EventModel();
			ev2.Summary = "Title 2";
			ev2.Description = "Comment 2";
			ev2.Start = new iCalDateTime(DateTime.Now);
			ev2.End = new iCalDateTime(DateTime.Now);

			EventCollection collection = new EventCollection();

			//Act
			collection.Add(ev);
			collection.Add(ev2);

			collection.Clear();

			//Assert
			Assert.AreEqual(0, collection.Count);
		}

		[Test]
		public void EventCollectionReturnsNullIfDoesntContainsGivenObject()
		{
			//Arrange
			string guid = Guid.NewGuid().ToString();

			EventModel ev = new EventModel();
			ev.Summary = "Title";
			ev.Description = "Comment";
			ev.Start = new iCalDateTime(DateTime.Now);
			ev.End = new iCalDateTime(DateTime.Now);
			ev.UID = guid;

			EventCollection collection = new EventCollection();

			//Act
			collection.Add(ev);

			//Assert
			Assert.IsNull(collection.Get(Guid.NewGuid().ToString()));
		}

		[Test]
		public void EventCollectionReturnsProperItemsInForEachLoop()
		{
			//Arrange
			string []guids = { Guid.NewGuid().ToString(), Guid.NewGuid().ToString() };

			EventModel ev = new EventModel();
			ev.Summary = "Title";
			ev.Description = "Comment";
			ev.Start = new iCalDateTime(DateTime.Now);
			ev.End = new iCalDateTime(DateTime.Now);
			ev.UID = guids[0];
			

			EventModel ev2 = new EventModel();
			ev2.Summary = "Title 2";
			ev2.Description = "Comment 2";
			ev2.Start = new iCalDateTime(DateTime.Now);
			ev2.End = new iCalDateTime(DateTime.Now);
			ev2.UID = guids[1];

			EventCollection collection = new EventCollection();

			//Act
			collection.Add(ev);
			collection.Add(ev2);

			bool succeed = true;

			foreach (IEvent item in collection)
			{
				if (!guids.Contains(item.UID))
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
			EventModel[] events = new EventModel[2];
			string guid = Guid.NewGuid().ToString();

			EventModel ev = new EventModel();
			ev.Summary = "Title";
			ev.Description = "Comment";
			ev.Start = new iCalDateTime(DateTime.Now);
			ev.End = new iCalDateTime(DateTime.Now);
			ev.UID = guid;

			EventModel ev2 = new EventModel();
			ev2.Summary = "Title 2";
			ev2.Description = "Comment 2";
			ev2.Start = new iCalDateTime(DateTime.Now);
			ev2.End = new iCalDateTime(DateTime.Now);
			ev2.UID = guid;

			EventCollection collection = new EventCollection();

			//Act
			collection.Add(ev);
			collection.Add(ev2);

			collection.CopyTo(events, 0);

			var count = CountItems(events);

			//Assert
			Assert.AreEqual(1, count);
		}

		[Test]
		public void EventCollectionReturnsProperCountOfItems()
		{
			Guid[] guids = { Guid.NewGuid(), Guid.NewGuid() };
			//Arrange
			string guid = Guid.NewGuid().ToString();

			EventModel ev = new EventModel();
			ev.Summary = "Title";
			ev.Description = "Comment";
			ev.Start = new iCalDateTime(DateTime.Now);
			ev.End = new iCalDateTime(DateTime.Now);
			ev.UID = guids[0].ToString();

			EventModel ev2 = new EventModel();
			ev2.Summary = "Title 2";
			ev2.Description = "Comment 2";
			ev2.Start = new iCalDateTime(DateTime.Now);
			ev2.End = new iCalDateTime(DateTime.Now);
			ev2.UID = guids[1].ToString();

			EventCollection collection = new EventCollection();


			//Act
			collection.Add(ev);
			collection.Add(ev2);

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
