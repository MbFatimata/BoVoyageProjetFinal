using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BoVoyageProjetFinal.Areas.BackOffice.Models;
using BoVoyageProjetFinal.Data;
using BoVoyageProjetFinal.Models;

namespace BoVoyageProjetFinal.Controllers
{
    public class TravelsController : BaseController
    {
        // GET: Travels
        public ActionResult Index(TravelBOViewModel model)
        {
            IEnumerable<Travel> liste = db.Travels.Include(x => x.Destination).Include(x => x.TravelAgency);

            if (model.DepartureDateMax != null)
                liste = liste.Where(x => x.DepartureDate <= model.DepartureDateMax);

            if (model.DepartureDateMin != null)
                liste = liste.Where(x => x.DepartureDate >= model.DepartureDateMin);

            if (model.ReturnDateMax != null)
                liste = liste.Where(x => x.ReturnDate <= model.ReturnDateMax);

            if (model.ReturnDateMin != null)
                liste = liste.Where(x => x.ReturnDate >= model.ReturnDateMin);

            if (model.AllInclusivePriceMax != null)
                liste = liste.Where(x => x.AllInclusivePrice <= model.AllInclusivePriceMax);

            if (model.AllInclusivePriceMin != null)
                liste = liste.Where(x => x.AllInclusivePrice >= model.AllInclusivePriceMin);

            if (!string.IsNullOrWhiteSpace(model.Continent))
                liste = db.Travels.Include(x => x.Destination).Include(x => x.TravelAgency).Where(x => x.Destination.Continent.Contains(model.Continent));

            if (!string.IsNullOrWhiteSpace(model.Country))
                liste = db.Travels.Include(x => x.Destination).Include(x => x.TravelAgency).Where(x => x.Destination.Country.Contains(model.Country));

            if (!string.IsNullOrWhiteSpace(model.Region))
                liste = db.Travels.Include(x => x.Destination).Include(x => x.TravelAgency).Where(x => x.Destination.Region.Contains(model.Region));

            if (!string.IsNullOrWhiteSpace(model.Name))
                liste = db.Travels.Include(x => x.Destination).Include(x => x.TravelAgency).Where(x => x.TravelAgency.Name.Contains(model.Name));

            model.TravelsBO = liste.ToList();
            return View(model);
        }


        // GET: Travels/Details/5
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
