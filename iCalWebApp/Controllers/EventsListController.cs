using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Core.Events;
using iCalWebApp.Models;

namespace iCalWebApp.Controllers
{
	public class EventsListController : Controller
	{
		//public List<EventModel> Events = new List<EventModel>();
		// GET: EventsList
		public ActionResult Index()
		{
			return View(FetchEvents());
		}

		/// <summary>
		/// Dodaje nowy obiekt EventModel do listy zdefiniowanych eventów
		/// </summary>
		/// <param name="model">obiekt modelu do dodania</param>
		private void AddEvent(EventModel model)
		{
			EventCollectionModel events = FetchEvents();

			events.Add(model);
		}

		/// <summary>
		/// Pobiera zapisaną w sesji listę obiektów EventModel
		/// </summary>
		/// <returns>Zwraca listę EventModel</returns>
		private EventCollectionModel FetchEvents()
		{
			if (Session["Events"] == null)
			{
				Session["Events"] = new EventCollectionModel();
				return FetchEvents();
			}

			return (EventCollectionModel) Session["Events"];

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
		public ActionResult Edit(Guid id)
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
				//EventModel old = FetchEvents().Get(id);
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
		/// <param name="model">Model do usunięcia</param>
		/// <returns></returns>
		// GET: EventsList/Delete/5
		public ActionResult Delete(Guid id)
		{
			return View(FetchEvents().Get(id));
		}

		// POST: EventsList/Delete/5
		[HttpPost]
		public ActionResult Delete(Guid id, FormCollection collection)
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
	}
}
