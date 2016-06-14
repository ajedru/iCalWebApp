using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Core.Events;
using Core.Interfaces;
using iCalWebApp.Models;
using Event = DDay.iCal.Event;
using System.IO;

namespace iCalWebApp.Controllers
{
	public class EventsListController : Controller
	{
		//public List<Event> Events = new List<Event>();
		// GET: EventsList
		public ActionResult Index()
		{
			return View(FetchEvents());
		}

		/// <summary>
		/// Dodaje nowy obiekt Event do listy zdefiniowanych eventów
		/// </summary>
		/// <param name="model">obiekt modelu do dodania</param>
		private void AddEvent(EventModel model)
		{
			EventCollection events = FetchEvents();

			events.Add(model);
		}

		/// <summary>
		/// Pobiera zapisaną w sesji listę obiektów Event
		/// </summary>
		/// <returns>Zwraca listę Event</returns>
		private EventCollection FetchEvents()
		{
			if (Session["Events"] == null)
			{
				Session["Events"] = new EventCollection();
				return FetchEvents();
			}

			return (EventCollection) Session["Events"];

		}
	  
		// GET: EventsList/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: EventsList/Create
		[HttpPost]
		public ActionResult Create(EventModel model)
		{
			try
			{
				if (ModelState.IsValid)
				{
					/*if (model.SelectedFrequency.Any())
					{
						model.Recurrence = model.SelectedFrequency;
					}*/
					AddEvent(model);
				}

				return RedirectToAction("Index");
			}
			catch
			{
				return View();
			}
		}

		// GET: EventsList/Edit/5
		public ActionResult Edit(string id)
		{
			EventModel model = FetchEvents().Get(id);
			return View(model);
		}

		// POST: EventsList/Edit/5
		[HttpPost]
		public ActionResult Edit(EventModel model, FormCollection collection)
		{
			try
			{
				//Event old = FetchEvents().Get(id);
				//model.Guid = old.Guid;
				if (ModelState.IsValid)
				{
					AddEvent(model);
				}

				return RedirectToAction("Index");
				
			}
			catch
			{
				return View();
			}
		}

		/// <summary>
		/// Usuwa podany event z listy eventów na stronie
		/// </summary>
		/// <param name="id">guid modelu do usunięcia</param>
		/// <returns></returns>
		// GET: EventsList/Delete/5
		public ActionResult Delete(string id)
		{
			return View(FetchEvents().Get(id));
		}

		// POST: EventsList/Delete/5
		[HttpPost]
		public ActionResult Delete(string id, FormCollection collection)
		{
			try
			{
				FetchEvents().Remove(id);

				return RedirectToAction("Index");
			}
			catch
			{
				return View();
			}
		}

		public ActionResult DeleteAll()
		{
			return View(FetchEvents());
		}

        public ActionResult DownloadCalendar()
        {
            Parser iCalParser = new Parser();
            String filePath = String.Format(@"files\{0}.ics", Guid.NewGuid()); // this is file path

			foreach (EventModel @event in FetchEvents())
	        {
		        iCalParser.calendar.Events.Add(@event);
	        }

			using (StreamWriter outputFile = new StreamWriter(filePath))
            {
                outputFile.Write(iCalParser.ParseToString());
            }

			return null;
        }

        [HttpPost]
		public ActionResult DeleteAll(FormCollection collection)
		{
			try
			{
				FetchEvents().Clear();

				return RedirectToAction("Index");
			}
			catch
			{
				return View();
			}
		}
	}
}
