using BoVoyageProjetFinal.Data;
using BoVoyageProjetFinal.filters;
using BoVoyageProjetFinal.Models;
using BoVoyageProjetFinal.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BoVoyageProjetFinal.Controllers
{
    public class AuthenticationClientController : BaseController
    {
        private BoVoyageDbContext db = new BoVoyageDbContext();
        // GET: /AuthenticationClient/Login
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
                    Session.Add("CLIENT", client);
                    return RedirectToAction("Index", "HomeClient");// a modifier pour rediriger ver la site Web Client
                }
            }
            return View(model);
        }

        [AuthenticationClientFilter]
        // Gey: AuthenticationClient/Logout
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Index", "Home");
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
