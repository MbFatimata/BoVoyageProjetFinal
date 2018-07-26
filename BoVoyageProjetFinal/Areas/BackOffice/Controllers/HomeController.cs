using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BoVoyageProjetFinal.Areas.BackOffice.Controllers
{
    public class HomeController : Controller
    {
        // GET: BackOffice/Home
        public ActionResult Index()
        {
            return View();
        }
    }
}