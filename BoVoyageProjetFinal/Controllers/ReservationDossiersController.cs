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
using BoVoyageProjetFinal.Utils;

namespace BoVoyageProjetFinal.Controllers
{
    public class ReservationDossiersController : BaseController
    {
        // GET: ReservationDossiers
        public ActionResult Index()
        {
            var reservationDossiers = db.ReservationDossiers.Include(r => r.Client).Include(r => r.Travel);
            return View(reservationDossiers.ToList());
        }

        // GET: ReservationDossiers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //ReservationDossier reservationDossier = db.ReservationDossiers.Find(id);
            ReservationDossier reservationDossier = db.ReservationDossiers.Include(x => x.Participants).Include(x => x.Client).SingleOrDefault(x => x.ID == id);
            if (reservationDossier == null)
            {
                return HttpNotFound();
            }
            return View(reservationDossier);
        }

        // GET: ReservationDossiers/Create
        public ActionResult Create()
        {
            ViewBag.ClientID = new SelectList(db.Clients, "ID", "Mail");
            ViewBag.TravelID = new SelectList(db.Travels, "ID", "ID");
            return View();
        }

        // POST: ReservationDossiers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Insurance,CreditCardNumber,TotalPrice,TravelID,ClientID,ReservationDossierStatus")] ReservationDossier reservationDossier)
        {
            if (ModelState.IsValid)
            {

                db.Configuration.ValidateOnSaveEnabled = false;
                reservationDossier.CreditCardNumber = reservationDossier.CreditCardNumber.HashMD5();
                db.ReservationDossiers.Add(reservationDossier);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClientID = new SelectList(db.Clients, "ID", "Mail", reservationDossier.ClientID);
            ViewBag.TravelID = new SelectList(db.Travels, "ID", "ID", reservationDossier.TravelID);
            return View(reservationDossier);
        }

        // GET: ReservationDossiers/Edit/
        public ActionResult Edit()
        {
            int? id = null;
            if (Session["Travel"] != null)
            {
                id = ((Travel)Session["TRAVEL"]).ID;
            }
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
            ViewBag.TravelID = new SelectList(db.Travels, "ID", "ID", reservationDossier.TravelID);
            return View(reservationDossier);
        }

        // POST: ReservationDossiers/Edit/5
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
            ViewBag.TravelID = new SelectList(db.Travels, "ID", "ID", reservationDossier.TravelID);
            return View(reservationDossier);
        }

        // GET: ReservationDossiers/Delete/5
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

        // POST: ReservationDossiers/Delete/5
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
