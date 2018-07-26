using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BoVoyageProjetFinal.Data;
using BoVoyageProjetFinal.Models;

namespace BoVoyageProjetFinal.Controllers
{
    public class TravelsController : Controller
    {
        private BoVoyageDbContext db = new BoVoyageDbContext();

        // GET: Travels
        public ActionResult Index()
        {
            var travels = db.Travels.Include(t => t.Destination).Include(t => t.TravelAgency);
            return View(travels.ToList());
        }

        // GET: Travels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Travel travel = db.Travels.Find(id);
            if (travel == null)
            {
                return HttpNotFound();
            }
            return View(travel);
        }


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
