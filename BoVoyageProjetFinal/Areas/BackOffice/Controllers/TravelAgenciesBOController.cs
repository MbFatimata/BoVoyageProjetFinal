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
    public class TravelAgenciesBOController : BaseController
    {
        // GET: BackOffice/TravelAgenciesBO
        public ActionResult Index()
        {
            return View(db.TravelAgencies.ToList());
        }

        // GET: BackOffice/TravelAgenciesBO/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TravelAgency travelAgency = db.TravelAgencies.Find(id);
            if (travelAgency == null)
            {
                return HttpNotFound();
            }
            return View(travelAgency);
        }

        // GET: BackOffice/TravelAgenciesBO/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BackOffice/TravelAgenciesBO/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name")] TravelAgency travelAgency)
        {
            if (ModelState.IsValid)
            {
                db.TravelAgencies.Add(travelAgency);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(travelAgency);
        }

        // GET: BackOffice/TravelAgenciesBO/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TravelAgency travelAgency = db.TravelAgencies.Find(id);
            if (travelAgency == null)
            {
                return HttpNotFound();
            }
            return View(travelAgency);
        }

        // POST: BackOffice/TravelAgenciesBO/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name")] TravelAgency travelAgency)
        {
            if (ModelState.IsValid)
            {
                db.Entry(travelAgency).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(travelAgency);
        }

        // GET: BackOffice/TravelAgenciesBO/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TravelAgency travelAgency = db.TravelAgencies.Find(id);
            if (travelAgency == null)
            {
                return HttpNotFound();
            }
            return View(travelAgency);
        }

        // POST: BackOffice/TravelAgenciesBO/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TravelAgency travelAgency = db.TravelAgencies.Find(id);
            if (travelAgency == null)
            {
                return RedirectToAction("Index");
            }

            // Cherche si l'agence propose au moins un voyage
            var agencyexistingtravels = db.Travels.Where(x => x.TravelAgencyID == id).Count();
            if (agencyexistingtravels != 0)
            {
                DisplayMessage("Cette agence propose des voyages et ne peut donc pas être supprimée !!!", MessageType.ERROR);
                return RedirectToAction("Index");
            }

            // db.TravelAgenciesBO.Remove(travelAgency);
            travelAgency.Deleted = true;
            travelAgency.DeletedAt = DateTime.Now;
            db.Entry(travelAgency).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            TempData["Message"] = "Cette agence a été correctement supprimée !!!";
            DisplayMessage("Cette agence a été correctement supprimée !!!", MessageType.SUCCESS);
            return RedirectToAction("Index");
        }
    }
}