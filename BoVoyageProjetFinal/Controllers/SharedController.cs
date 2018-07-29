using BoVoyageProjetFinal.Data;
using BoVoyageProjetFinal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BoVoyageProjetFinal.Controllers
{
    public class SharedController : BaseController
    {
        protected BoVoyageDbContext db = new BoVoyageDbContext();

        // GET: Shared
        [ChildActionOnly]
        public ActionResult TopFiveTravelsDepartureDate()
        {
            var travels = db.Travels.Include("Destination")
                .Include("TravelAgency")
                .OrderBy(x => x.DepartureDate)
                .Take(5);

            return View("_TopFiveTravelsDepartureDate", travels);
        }

        // GET: Shared
        [ChildActionOnly]
        public ActionResult TopFiveAllInclusivePrice()
        {
            var travels = db.Travels.Include("Destination")
                .Include("TravelAgency")
                .OrderBy(x => x.AllInclusivePrice)
                .Take(5);

            return View("_TopFiveTravelsDepartureDate", travels);
        }

        // GET: Shared
        [ChildActionOnly]
        public ActionResult TopFiveTravelsCountry()
        {
            var destination = db.Travels.Include("Destination")
                .GroupBy(x => x.Destination.Country)
                .OrderByDescending(x => x.Count())
                .Take(5);

            return View("_TopFiveTravelsCountry", destination);
        }
    }
}