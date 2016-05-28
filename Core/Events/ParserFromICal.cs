using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DDay.iCal;

namespace Core.Events
{
    class ParserFromICal : IParserFromICal
    {
        public iCalendar Parse(string fileString)
        {
            IICalendarCollection calendarColl = iCalendar.LoadFromFile(fileString);
            iCalendar iCal = new iCalendar();
            foreach(iCalendar cacheiCal in calendarColl)
            {
                iCal = cacheiCal;
                break; //taking only one element from collection
            }

            return iCal;
        }
    }
}
