using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BoVoyageProjetFinal.Controllers;
using BoVoyageProjetFinal.Data;
using BoVoyageProjetFinal.Models;

namespace BoVoyageProjetFinal.Areas.BackOffice.Controllers
{
    public class TravelsBOController : BaseController
    {
        // GET: BackOffice/TravelsBO
        public ActionResult Index()
        {
            var travels = db.Travels.Include(t => t.Destination).Include(t => t.TravelAgency);
            return View(travels.ToList());
        }

        // GET: BackOffice/TravelsBO/Details/5
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

        // GET: BackOffice/TravelsBO/Create
        public ActionResult Create()
        {
            ViewBag.DestinationID = new SelectList(db.Destinations, "ID", "Continent");
            ViewBag.TravelAgencyID = new SelectList(db.TravelAgencies, "ID", "Name");
            return View();
        }

        // POST: BackOffice/TravelsBO/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,DepartureDate,ReturnDate,AvailablePlaces,AllInclusivePrice,TravelAgencyID,DestinationID,CreatedAt,Deleted,DeletedAt")] Travel travel)
        {
            if (ModelState.IsValid)
            {
                db.Travels.Add(travel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DestinationID = new SelectList(db.Destinations, "ID", "Continent", travel.DestinationID);
            ViewBag.TravelAgencyID = new SelectList(db.TravelAgencies, "ID", "Name", travel.TravelAgencyID);
            return View(travel);
        }

        //GET: BackOffice/TravelsBO/search
        public ActionResult Search(DateTime? departureDate = null, DateTime? returnDate = null, Decimal? allInclusivePrice = null)
        {
            IQueryable<Travel> liste = db.Travels.Where(x => !x.Deleted);

            if (departureDate != null)
                liste = liste.Where(x => x.DepartureDate == departureDate);

            if (returnDate != null)
                liste = liste.Where(x => x.ReturnDate == returnDate);

            if (allInclusivePrice != null)
                liste = liste.Where(x => x.AllInclusivePrice == allInclusivePrice);

            return View("Index", liste);
        }

        // GET: BackOffice/TravelsBO/Edit/5
        public ActionResult Edit(int? id)
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
            ViewBag.DestinationID = new SelectList(db.Destinations, "ID", "Continent", travel.DestinationID);
            ViewBag.TravelAgencyID = new SelectList(db.TravelAgencies, "ID", "Name", travel.TravelAgencyID);
            return View(travel);
        }

        // POST: BackOffice/TravelsBO/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,DepartureDate,ReturnDate,AvailablePlaces,AllInclusivePrice,TravelAgencyID,DestinationID,CreatedAt,Deleted,DeletedAt")] Travel travel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(travel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DestinationID = new SelectList(db.Destinations, "ID", "Continent", travel.DestinationID);
            ViewBag.TravelAgencyID = new SelectList(db.TravelAgencies, "ID", "Name", travel.TravelAgencyID);
            return View(travel);
        }

        // GET: BackOffice/TravelsBO/Delete/5
        public ActionResult Delete(int? id)
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

        // POST: BackOffice/TravelsBO/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Travel travel = db.Travels.Find(id);
            db.Travels.Remove(travel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
