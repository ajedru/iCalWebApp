using System;
using Core.Events;
using Core.Interfaces;
using NUnit.Framework;

namespace Core.Tests.Events
{
    [TestFixture]
    public class EventTest
    {
        [Test]
        public void EventCreateNewEventObject()
        {
            //Arrange
            string title = "title";
            string comment = "comment";

            DateTime from = new DateTime(2000, 06, 10);
            DateTime to = new DateTime(2000, 06, 20);

            Guid guid = Guid.NewGuid();

            DateTime creationDate = DateTime.Now;
            
            IDateRange DateRange = new DateRange(from, to);

            Event myEvent = new Event(title, comment, DateRange, creationDate, guid);

            //Assert
            Assert.AreEqual(new[]
            {
                title, comment, from.ToString(), to.ToString(), creationDate.ToString(), guid.ToString()
            }, new[]
            {
                myEvent.Title, myEvent.Comment, myEvent.DateRange.From.ToString(), myEvent.DateRange.To.ToString(), myEvent.CreationDate.ToString(), myEvent.Guid.ToString()
            });




        }


    }
}
