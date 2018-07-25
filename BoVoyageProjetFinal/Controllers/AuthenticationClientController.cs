using BoVoyageProjetFinal.Data;
using BoVoyageProjetFinal.Models;
using BoVoyageProjetFinal.Views.Clients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BoVoyageProjetFinal.Controllers
{
    public class AuthenticationClientController : Controller
    {
        private BoVoyageDbContext db = new BoVoyageDbContext();
        // GET: BackOffice/Authentication/Login
        public ActionResult Login()
        {
            return View();
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Login(AuthenticationClientLoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var passwordHash = model.Password.HashMD5();
                var client = db.Clients.SingleOrDefault(x => x.Mail == model.Login && x.Password == passwordHash);
                if (client == null)
                {
                    //1
                    //ModelState.AddModelError("", "Utilisateur ou mot de passe incorrect.");

                    //2
                    ViewBag.ErrorMessage = "Utilisateur ou mot de passe incorrect.";
                    return View(model);
                }
                else
                {
                    Session.Add("CLIENT_BO", client);
                    return RedirectToAction("Index", "Home");
                }
            }
            return View(model);

        }


        protected override void Dispose(bool disposing) //pour liberer connexion à la base de donnees lorque controleur a fini de l'utiliser
        {
           if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
