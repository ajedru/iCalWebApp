using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using iCalWebApp.Models;

namespace iCalWebApp.Controllers
{
	
	public class EventsListController : ApiController
	{

		private EventModel[] events = new EventModel[]
		{
			new EventModel { }
		};

		public IEnumerable<EventModel> GetAllEvents()
		{
			return events;
		}
	}
}
