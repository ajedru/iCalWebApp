using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using iCalWebApp.Models;

namespace iCalWebApp.Controllers
{
    public class EventsListController : Controller
    {
	    public List<EventModel> Events = new List<EventModel>();
        // GET: EventsList
        public ActionResult Index()
        {
            return View(Events);
        }
	  
        // GET: EventsList/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EventsList/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
	            foreach (var key in collection)
	            {
		            
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

        // GET: EventsList/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
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
