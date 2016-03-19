using System;
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
			IEvent ev2 = new Event("Title", "Comment", new DateRange(DateTime.Now, DateTime.Now), DateTime.Now, guid);
			EventCollection collection = new EventCollection();

			//Act
			collection.Add(ev);
			collection.Add(ev2);

			collection.Remove(ev2);

			//Assert
			Assert.IsFalse(collection.Contains(guid));
		}
	}
}
