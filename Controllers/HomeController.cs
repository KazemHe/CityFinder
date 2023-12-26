using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CityFinder.Models;
using PagedList;

namespace CityFinder.Controllers
{
    public class HomeController : Controller
    {
        private IsraeliCitiesDbContext db = new IsraeliCitiesDbContext();

        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var cities = from s in db.Cities
                         select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                cities = cities.Where(s => s.Name.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    cities = cities.OrderByDescending(s => s.Name);
                    break;
                default:
                    cities = cities.OrderBy(s => s.Name);
                    break;
            }

            int pageSize = 5;
            int pageNumber = (page ?? 1);
            return View(cities.ToPagedList(pageNumber, pageSize));
        }

        // ... Other actions like About, Contact remain unchanged

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
