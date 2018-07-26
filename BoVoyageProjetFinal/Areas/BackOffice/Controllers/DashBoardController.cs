using BoVoyageProjetFinal.filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BoVoyageProjetFinal.Areas.BackOffice
{
    //[AuthenticationSalesmanFilter]
    public class DashBoardController : Controller
    {
        // GET: BackOffice/DashBoard
        public ActionResult Index()
        {
            return View();
        }
    }
}