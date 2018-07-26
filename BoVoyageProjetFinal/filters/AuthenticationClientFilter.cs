using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BoVoyageProjetFinal.filters
{
    public class AuthenticationClientFilter: ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.HttpContext.Session["CLIENT"] == null)
            {
                filterContext.Result = new RedirectResult("\\AuthenticationClient\\Login");
            }

        }
    }
}