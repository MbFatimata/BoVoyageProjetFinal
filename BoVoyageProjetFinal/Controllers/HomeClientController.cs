using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BoVoyageProjetFinal.Controllers
{
    public class HomeClientController : BaseController
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

    }
}