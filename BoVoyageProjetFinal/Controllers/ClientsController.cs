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
    public class ClientsController : Controller
    {
        private BoVoyageDbContext db = new BoVoyageDbContext();


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
                return RedirectToAction("Index","Home");
            }

            ViewBag.CivilityID = new SelectList(db.Civilities, "ID", "Label", client.CivilityID);
            return View(client);
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
