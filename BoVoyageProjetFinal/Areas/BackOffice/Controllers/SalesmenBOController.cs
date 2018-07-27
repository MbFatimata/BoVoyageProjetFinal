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
using BoVoyageProjetFinal.Utils;

namespace BoVoyageProjetFinal.Areas.BackOffice.Controllers
{
    public class SalesmenBOController : BaseController
    {
        // GET: BackOffice/SalesmenBO
        public ActionResult Index()
        {
            var salesmen = db.Salesmen.Where(x => !x.Deleted).Include(s => s.Civility);
            return View(salesmen.ToList());
        }

        // GET: BackOffice/SalesmenBO/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Salesman salesman = db.Salesmen.Find(id);
            if (salesman == null)
            {
                return HttpNotFound();
            }
            return View(salesman);
        }

        // GET: BackOffice/SalesmenBO/Create
        public ActionResult Create()
        {
            ViewBag.CivilityID = new SelectList(db.Civilities, "ID", "Label");
            return View();
        }

        // POST: BackOffice/SalesmenBO/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Mail,Password,ConfirmedPassword,LastName,FirstName,Address,Telephone,Birthdate,CivilityID")] Salesman salesman)
        {

            if (ModelState.IsValid)
            {
                db.Configuration.ValidateOnSaveEnabled = false;
                salesman.Password = salesman.Password.HashMD5();
                db.Salesmen.Add(salesman);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CivilityID = new SelectList(db.Civilities, "ID", "Label", salesman.CivilityID);
            return View(salesman);
        }

        // GET: BackOffice/SalesmenBO/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Salesman salesman = db.Salesmen.Find(id);
            if (salesman == null)
            {
                return HttpNotFound();
            }
            ViewBag.CivilityID = new SelectList(db.Civilities, "ID", "Label", salesman.CivilityID);
            return View(salesman);
        }

        // POST: BackOffice/SalesmenBO/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Mail,Password,ConfirmedPassword,LastName,FirstName,Address,Telephone,Birthdate,CivilityID")] Salesman salesman)
        {
            if (ModelState.IsValid)
            {
                db.Entry(salesman).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CivilityID = new SelectList(db.Civilities, "ID", "Label", salesman.CivilityID);
            return View(salesman);
        }

        // GET: BackOffice/SalesmenBO/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Salesman salesman = db.Salesmen.Find(id);
            if (salesman == null)
            {
                return HttpNotFound();
            }
            return View(salesman);
        }

        // POST: BackOffice/SalesmenBO/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Salesman salesman = db.Salesmen.Find(id);
            db.Salesmen.Remove(salesman);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
