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
            return View("_TopFifteenTravels", travels);
        }

        [ChildActionOnly]
        public ActionResult DossiersReservationsAwaitingReturn()
        {
            var reservations = db.ReservationDossiers.Include("Client").Include("Participant").Include("Travel").GroupBy(x => x.ReservationDossierStatus == 0);
            return View("_DossiersReservationsAwaitingReturn", reservations);
        }
    }
}