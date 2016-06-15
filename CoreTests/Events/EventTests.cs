using System;
using Core.Events;
using Core.Interfaces;
using DDay.iCal;
using NUnit.Framework;

namespace Core.Tests.Events
{
	[TestFixture]
	public class EventTests
	{
	    [Test]
	    public void CreateNewEventModelFromEventObject()
	    {

	        //Arrange
	        string summary = "title";
	        string description = "comment";
	        IDateTime from = new iCalDateTime(2000, 06, 10);
	        IDateTime to = new iCalDateTime(2000, 06, 20);
	        Event @event = new Event();
	        @event.Start = from;
	        @event.End = to;
	        @event.Summary = summary;
	        @event.Description = description;

	        //Act
	        EventModel eventModel = new EventModel(@event);

	        //Assert
	        Assert.AreEqual(new[] {"title","comment",from.ToString(),to.ToString()}, new[] {eventModel.Summary,eventModel.Description,eventModel.From.ToString(),eventModel.To.ToString()});
	    }

	    [Test]
	    public void ConvertsFromTimeSpanToDateTime()
	    {
	       //Arrange
            EventModel eventModel = new EventModel();
            DateTime dateTime = new DateTime(2016,12,20,11,30,0);
	        eventModel.From = dateTime;
            dateTime = new DateTime(2016, 12, 20, 10, 30, 0);
            TimeSpan timeSpan = new TimeSpan(0,1,0,0);
	        //Assert   
            Assert.AreEqual(eventModel.DateFromTimeSpan(timeSpan).ToString(),dateTime.ToString());
	    }

        [Test]
        public void ConvertsFromDateTimeToTimeSpan()
        {
            //Arrange
            EventModel eventModel = new EventModel();
            DateTime eventDateTime = new DateTime(2016, 12, 20, 11, 30, 0);
            DateTime dateTime = new DateTime(2016, 12, 20, 10, 30, 0);
            TimeSpan timeSpan = new TimeSpan(0, 1, 0, 0);
            eventModel.From = eventDateTime;
            //Assert   
            Assert.AreEqual(eventModel.DateToTimeSpan(dateTime).ToString(), timeSpan.ToString());
        }

        [Test]
        public void FromVariableSetterAndGetterWhenConditionIsTrueIsCorrect()
        {
            //Arrange
            EventModel eventModel = new EventModel();
            DateTime dateTime = new DateTime(2016, 12, 20, 10, 30, 0);
            eventModel.From = dateTime;
            
            //Assert   
            Assert.AreEqual(eventModel.From.ToString(),dateTime.ToString());
        }

        [Test]
        public void FromVariableGetterWhenConditionIsFalseIsCorrect()
        {
            //Arrange
            EventModel eventModel = new EventModel();

            //Assert   
            Assert.AreEqual(eventModel.From.ToString(), DateTime.MinValue.ToString());
        }

        [Test]
        public void ToVariableSetterAndGetterWhenConditionIsTrueIsCorrect()
        {
            //Arrange
            EventModel eventModel = new EventModel();
            DateTime dateTime = new DateTime(2016, 12, 20, 10, 30, 0);
            eventModel.To = dateTime;

            //Assert   
            Assert.AreEqual(eventModel.To.ToString(), dateTime.ToString());
        }

        [Test]
        public void ToVariableGetterWhenConditionIsFalseIsCorrect()
        {
            //Arrange
            EventModel eventModel = new EventModel();

            //Assert   
            Assert.AreEqual(eventModel.To.ToString(), DateTime.MinValue.ToString());
        }

        [Test]
        public void AlarmVariableSetterAndGetterWhenConditionIsTrueIsCorrect()
        {
            //Arrange
            EventModel eventModel = new EventModel();
            Alarm alarm = new Alarm();
            alarm.Trigger = new Trigger(new TimeSpan(0, 0, -15, 0));
            eventModel.AlarmObj = alarm;
            //Console.Write(alarm.Trigger.Duration);

            //Assert   
            Assert.AreEqual(eventModel.AlarmObj.Trigger.Duration,alarm.Trigger.Duration);

        }

        [Test]
        public void AlarmVariableGetterWhenConditionIsFlaseIsCorrect()
        {
            //Arrange
            EventModel eventModel = new EventModel();
            Alarm alarm = new Alarm();
            //Assert   
            Assert.AreEqual(eventModel.AlarmObj.Duration, alarm.Duration);
        }

    }
}
