using DDay.iCal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    interface IParserToICal
    {
        Alarm CreateAlarm(int days, int hours, int minutes, int seconds);
        void CreateAndAddEvent(string summary, string description, DateTime start, DateTime end, Alarm alarm);
        IDateTime DateToiCalDate(DateTime date);
        string ParseToICalString();
    }
}
