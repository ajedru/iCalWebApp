using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
	public interface IParser
	{
		string Parse(EventCollection events);
	}
}
