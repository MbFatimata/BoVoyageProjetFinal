using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BoVoyageProjetFinal.Areas.BackOffice.Models;
using BoVoyageProjetFinal.Controllers;
using BoVoyageProjetFinal.Data;
using BoVoyageProjetFinal.Models;

namespace BoVoyageProjetFinal.Areas.BackOffice.Controllers
{
    public class ClientsBOController : BaseController
    {
        // GET: BackOffice/ClientsBO
        public ActionResult Index(ClientBOViewModel model)
        {
            IEnumerable<Client> clients = db.Clients;

            if (!string.IsNullOrWhiteSpace(model.LastName))
                clients = db.Clients.Where(x => x.LastName.Contains(model.LastName));

            if (!string.IsNullOrWhiteSpace(model.FirstName))
                clients = db.Clients.Where(x => x.FirstName.Contains(model.FirstName));

            if (model.BirthdateBefore != null)
                clients = db.Clients.Where(x => x.Birthdate <= model.BirthdateBefore);

            if (model.BirthdateAfter.HasValue)
                clients = db.Clients.Where(x => x.Birthdate >= model.BirthdateAfter);

            if (!string.IsNullOrWhiteSpace(model.Mail))
                clients = db.Clients.Where(x => x.Mail.Contains(model.Mail));

            if (!string.IsNullOrWhiteSpace(model.Telephone))
                clients = db.Clients.Where(x => x.Telephone.Contains(model.Telephone));

            model.ClientsBO = clients.ToList();
            return View(model);
        }

        // GET: BackOffice/ClientsBO/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client client = db.Clients.Find(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }

        // GET: BackOffice/ClientsBO/Create
        public ActionResult Create()
        {
            ViewBag.CivilityID = new SelectList(db.Civilities, "ID", "Label");
            return View();
        }

        // POST: BackOffice/ClientsBO/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Mail,Password,LastName,FirstName,Address,Telephone,Birthdate,CivilityID,CreatedAt,Deleted,DeletedAt")] Client client)
        {
            if (ModelState.IsValid)
            {
                db.Clients.Add(client);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CivilityID = new SelectList(db.Civilities, "ID", "Label", client.CivilityID);
            return View(client);
        }

        // GET: BackOffice/ClientsBO/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client client = db.Clients.Find(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            ViewBag.CivilityID = new SelectList(db.Civilities, "ID", "Label", client.CivilityID);
            return View(client);
        }

        // POST: BackOffice/ClientsBO/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Mail,Password,LastName,FirstName,Address,Telephone,Birthdate,CivilityID,CreatedAt,Deleted,DeletedAt")] Client client)
        {
            if (ModelState.IsValid)
            {
                db.Entry(client).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CivilityID = new SelectList(db.Civilities, "ID", "Label", client.CivilityID);
            return View(client);
        }

        // GET: BackOffice/ClientsBO/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client client = db.Clients.Find(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }

        // POST: BackOffice/ClientsBO/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Client client = db.Clients.Find(id);
            db.Clients.Remove(client);
            db.SaveChanges();
            return RedirectToAction("Index");
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
