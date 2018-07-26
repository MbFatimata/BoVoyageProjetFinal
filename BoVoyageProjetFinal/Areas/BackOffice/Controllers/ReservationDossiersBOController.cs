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
    public class ReservationDossiersBOController : BaseController
    {
        // GET: BackOffice/ReservationDossiersBO
        public ActionResult Index()
        {
            var reservationDossiers = db.ReservationDossiers.Include(r => r.Client).Include(r => r.Travel);
            return View(reservationDossiers.ToList());
        }

        // GET: BackOffice/ReservationDossiersBO/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReservationDossier reservationDossier = db.ReservationDossiers.Find(id);
            if (reservationDossier == null)
            {
                return HttpNotFound();
            }
            return View(reservationDossier);
        }

        // GET: BackOffice/ReservationDossiersBO/Create
        public ActionResult Create()
        {
            ViewBag.ClientID = new SelectList(db.Clients, "ID", "Mail");
            ViewBag.TravelID = new SelectList(db.TravelsBO, "ID", "ID");
            return View();
        }

        // POST: BackOffice/ReservationDossiersBO/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Insurance,CreditCardNumber,TotalPrice,TravelID,ClientID,ReservationDossierStatus,ReasonCancellationDossier,CreatedAt,Deleted,DeletedAt")] ReservationDossier reservationDossier)
        {
            if (ModelState.IsValid)
            {
                db.ReservationDossiers.Add(reservationDossier);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClientID = new SelectList(db.Clients, "ID", "Mail", reservationDossier.ClientID);
            ViewBag.TravelID = new SelectList(db.TravelsBO, "ID", "ID", reservationDossier.TravelID);
            return View(reservationDossier);
        }

        // GET: BackOffice/ReservationDossiersBO/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReservationDossier reservationDossier = db.ReservationDossiers.Find(id);
            if (reservationDossier == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClientID = new SelectList(db.Clients, "ID", "Mail", reservationDossier.ClientID);
            ViewBag.TravelID = new SelectList(db.TravelsBO, "ID", "ID", reservationDossier.TravelID);
            return View(reservationDossier);
        }

        // POST: BackOffice/ReservationDossiersBO/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Insurance,CreditCardNumber,TotalPrice,TravelID,ClientID,ReservationDossierStatus,ReasonCancellationDossier,CreatedAt,Deleted,DeletedAt")] ReservationDossier reservationDossier)
        {
            if (ModelState.IsValid)
            {
                db.Entry(reservationDossier).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClientID = new SelectList(db.Clients, "ID", "Mail", reservationDossier.ClientID);
            ViewBag.TravelID = new SelectList(db.TravelsBO, "ID", "ID", reservationDossier.TravelID);
            return View(reservationDossier);
        }

        // GET: BackOffice/ReservationDossiersBO/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReservationDossier reservationDossier = db.ReservationDossiers.Find(id);
            if (reservationDossier == null)
            {
                return HttpNotFound();
            }
            return View(reservationDossier);
        }

        // POST: BackOffice/ReservationDossiersBO/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ReservationDossier reservationDossier = db.ReservationDossiers.Find(id);
            db.ReservationDossiers.Remove(reservationDossier);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
