using BoVoyageProjetFinal.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BoVoyageProjetFinal.Areas.BackOffice.Controllers
{
    public class SharedBOController : BaseController
    {
        // GET: Shared
        [ChildActionOnly]
        public ActionResult TopFifteenTravels()
        {

            var travels = db.Travels.Include("Destination").Include("TravelAgency").OrderBy(x => x.DepartureDate).Take(15);
            //var travels = db.Travels.OrderByDescending(x => x.DepartureDate).Take(15);
            return View("_TopFifteenTravels", travels);
        }
    }
}