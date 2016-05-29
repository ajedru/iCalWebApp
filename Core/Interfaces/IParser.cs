using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Events;
using DDay.iCal;

namespace Core.Interfaces
{
	public interface IParser
	{
		iCalendar ParseToCalendar(string content);

		string ParseToString();
	}
}
