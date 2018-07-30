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
    public class ClientsController : BaseController
    {
        // GET: /Clients
        public ActionResult Index()
        {
            int? id = null;
            if (Session["CLIENT"] != null)
            {
                id = ((Client)Session["CLIENT"]).ID;
            }
            Client client = db.Clients.Find(id);
            return View(client);
        }

        // GET: Clients/Details/5
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

        // GET: Clients/Create
        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.CivilityID = new SelectList(db.Civilities, "ID", "Label");
            return View();
        }

        // POST: Clients/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Mail,Password,ConfirmedPassword,LastName,FirstName,Address,Telephone,Birthdate,CivilityID")] Client client)
        {
            if (ModelState.IsValid)
            {
                db.Configuration.ValidateOnSaveEnabled = false;
                client.Password = client.Password.HashMD5();
                db.Clients.Add(client);
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }

            ViewBag.CivilityID = new SelectList(db.Civilities, "ID", "Label", client.CivilityID);
            return View(client);
        }

        // GET: Clients/Edit
        public ActionResult Edit()
        {
            int? id = null;
            if (Session["CLIENT"] != null)
            {
                id = ((Client)Session["CLIENT"]).ID;
            }
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

        // POST: Clients/Edit/
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Mail,LastName,FirstName,Address,Telephone,Birthdate,CivilityID")] Client client)
        {
            ModelState.Remove("Mail");

            if (ModelState.IsValid)
            {
                client.Password = client.Password.HashMD5();
                db.Entry(client).State = EntityState.Modified;
                db.Configuration.ValidateOnSaveEnabled = false;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CivilityID = new SelectList(db.Civilities, "ID", "Label", client.CivilityID);
            return View();
        }

        // GET: Clients/Delete/
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

        // POST: Clients/Delete/
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Client client = db.Clients.Find(id);
            db.Clients.Remove(client);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        // GET: Clients/ChangePassword/
        public ActionResult ChangePassword(int? id)
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
            return View();
        }

        // POST: BackOffice/SalesmenBO/ChangePassword/
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ChangePassword(ClientPasswordViewModel clientPasswordViewModel)
        {
            Client client = Session["CLIENT"] as Client;

            if (ModelState.IsValid)
            {
                db.Entry(client).State = EntityState.Modified;
                db.Configuration.ValidateOnSaveEnabled = false;
                client.Password = clientPasswordViewModel.Password.HashMD5();
                db.SaveChanges();

                DisplayMessage("Votre mot de passe a été correctement modifié !!!", MessageType.SUCCESS);

                return RedirectToAction("Index", "HomeClient");
            }
            DisplayMessage("Il y a malheureusement eu un souci :-(", MessageType.ERROR);
            return RedirectToAction("Index", "HomeClient");
        }
    }
}
