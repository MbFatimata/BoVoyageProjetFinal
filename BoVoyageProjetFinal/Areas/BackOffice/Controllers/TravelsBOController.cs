using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
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
            var travels = db.Travels.Where(t => !t.Deleted).Include(t => t.Destination).Include(t => t.TravelAgency);
            return View(travels.ToList());
        }

        // GET: BackOffice/TravelsBO/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //            Travel travel = db.Travels.Find(id);
            // Travel travel = db.Travels.Find(id).Include(t => t.Destination).Include(t => t.TravelAgency);
            // Room room = db.Rooms.Include(x => x.User).Include(x => x.Category).SingleOrDefault(x => x.ID == id);
            Travel travel = db.Travels.Include(x => x.Files).Include(t => t.Destination).Include(t => t.TravelAgency).SingleOrDefault(x => x.ID == id);
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
        public ActionResult Create([Bind(Include = "ID,DepartureDate,ReturnDate,AvailablePlaces,AllInclusivePrice,TravelAgencyID,DestinationID")] Travel travel)
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

        // GET: BackOffice/TravelsBO/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Travel travel = db.Travels.Include(x => x.Files).SingleOrDefault(x => x.ID == id);

            // Room room = db.Rooms.Include(x => x.Files).SingleOrDefault(x => x.ID == id);

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
        public ActionResult Edit([Bind(Include = "ID,DepartureDate,ReturnDate,AvailablePlaces,AllInclusivePrice,TravelAgencyID,DestinationID")] Travel travel)
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

            // Supprimer les imagesfiles en base car le cascade est false
            var travelFiles = db.TravelFiles.Where(x => x.TravelID == id).ToList();
            foreach (var travelFile in travelFiles)
            {
                db.TravelFiles.Remove(travelFile);
            }

            travel.Deleted = true;
            travel.DeletedAt = DateTime.Now;
            db.Entry(travel).State = System.Data.Entity.EntityState.Modified;

            DisplayMessage("Ce voyage a été correctement supprimée !!!", MessageType.SUCCESS);
            //db.Travels.Remove(travel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        [HttpPost]
        public ActionResult AddFile(int id, HttpPostedFileBase upload)
        {
            if (upload.ContentLength > 0)
            {
                var model = new TravelFile();

                model.TravelID = id;
                model.Name = upload.FileName;
                model.ContentType = upload.ContentType;

                using (var reader = new BinaryReader(upload.InputStream))
                {
                    model.Content = reader.ReadBytes(upload.ContentLength);
                }

                db.TravelFiles.Add(model);
                db.SaveChanges();
                DisplayMessage("Le fichier a bien été ajouté !!!", MessageType.SUCCESS);
                return RedirectToAction("Edit", new { id = model.TravelID });
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
        }


        [HttpGet]
        public ActionResult DeleteFile(int id)
        {
            // On ne conserve pas les travelFiles en base si on supprime les images (à la différence d'une suppression d'un travel)
            TravelFile travelFile = db.TravelFiles.Find(id);
            db.TravelFiles.Remove(travelFile);
            db.SaveChanges();

            DisplayMessage("Le fichier a bien été supprimé", MessageType.SUCCESS);
            return RedirectToAction("Edit", new { id = travelFile.TravelID });
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