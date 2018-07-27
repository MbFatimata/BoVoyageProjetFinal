using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BoVoyageProjetFinal.Controllers
{
    public class SharedController : BaseController
    {
        // GET: Shared
        [ChildActionOnly]
        public ActionResult TopFiveTravelsDepartureDate()
        {
            var travels = db.Travels.Include("Destination").Include("TravelAgency").OrderBy(x => x.DepartureDate).Take(5);
            return View("TopFiveTravelsDepartureDate", travels);
        }
    }
}