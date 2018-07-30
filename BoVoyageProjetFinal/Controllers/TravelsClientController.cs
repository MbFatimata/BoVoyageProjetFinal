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
    public class TravelsClientController : BaseController
    {
        // GET: TravelsClient
        public ActionResult Index()
        {
            var travels = db.Travels.Include(t => t.Destination).Include(t => t.TravelAgency);
            return View(travels.ToList());
        }

        // GET: TravelsClient/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Travel travel = db.Travels.Find(id);
            Travel travel = db.Travels.Include(x => x.Destination).Include(t => t.TravelAgency).Include(x => x.Files).SingleOrDefault(x => x.ID == id);
            if (travel == null)
            {
                return HttpNotFound();
            }
            return View(travel);
        }
    }
}
