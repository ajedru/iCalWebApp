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
			List<EventModel> events = FetchEvents();

			events.Add(model);
		}

		/// <summary>
		/// Pobiera zapisaną w sesji listę obiektów EventModel
		/// </summary>
		/// <returns>Zwraca listę EventModel</returns>
		private List<EventModel> FetchEvents()
		{
			if (Session["Events"] == null)
			{
				Session["Events"] = new List<EventModel>();
				return FetchEvents();
			}

			return (List<EventModel>) Session["Events"];

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
					model.DateRange = new DateRange(new DateTime(2016, 3, 15), new DateTime(2016, 3, 16));
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
		public ActionResult Edit(int id)
		{
			return View();
		}

		// POST: EventsList/Edit/5
		[HttpPost]
		public ActionResult Edit(int id, FormCollection collection)
		{
			try
			{
				// TODO: Add update logic here

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
		public ActionResult Delete(int id)
		{
			List<EventModel> events = FetchEvents();
			//events.Remove(model);

			return View(events);
		}

		// POST: EventsList/Delete/5
		[HttpPost]
		public ActionResult Delete(int id, FormCollection collection)
		{
			try
			{
				// TODO: Add delete logic here

				return RedirectToAction("Index");
			}
			catch
			{
				return View();
			}
		}
	}
}
