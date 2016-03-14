using Microsoft.VisualStudio.TestTools.UnitTesting;
using Core.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Events.Tests
{
    [TestClass]
    public class DateRangeTests
    {
        [TestMethod]
        public void DurationShouldReturnProperTimeSpan()
        {
            //Arrange
            DateTime from = new DateTime(2000, 06, 10);
            DateTime to = new DateTime(2000,06, 20);
            var dateRange = new DateRange(from, to);
            //Act
            TimeSpan result = dateRange.Duration;
            //Assert
            Assert.AreEqual(new TimeSpan(10,0,0,0), result);
        }
    }
}