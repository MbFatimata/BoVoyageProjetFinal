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

namespace BoVoyageProjetFinal.Controllers
{
    public class ContactMessagesController : BaseController
    {
        private BoVoyageDbContext db = new BoVoyageDbContext();

        // GET: ContactMessages/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ContactMessages/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Lastname,Firstname,Email,Message,CreatedAt,Deleted,DeletedAt")] ContactMessage contactMessage)
        {
            if (ModelState.IsValid)
            {
                db.ContactMessages.Add(contactMessage);
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }

            return View(contactMessage);
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
