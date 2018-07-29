using BoVoyageProjetFinal.Areas.BackOffice.Models;
using BoVoyageProjetFinal.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BoVoyageProjetFinal.Utils;
using BoVoyageProjetFinal.filters;
using BoVoyageProjetFinal.Controllers;

namespace BoVoyageProjetFinal.Areas.BackOffice.Controllers
{
    public class AuthenticationSalesmanController : BaseController
    {
        private BoVoyageDbContext db = new BoVoyageDbContext();

        // GET: /AuthenticationClient/Login
        public ActionResult Login()
        {
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Login(AuthenticationSalesmanLoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var passwordHash = model.Password.HashMD5();
                var client = db.Salesmen.SingleOrDefault(x => x.Mail == model.Login && x.Password == passwordHash);
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
                    Session.Add("USER_BO", client);
                    return RedirectToAction("Index", "DashBoard");
                }
            }
            return View(model);
        }

        [AuthenticationSalesmanFilter]
        // GeT: AuthenticationClient/Logout
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Index", "DashBoard");
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
