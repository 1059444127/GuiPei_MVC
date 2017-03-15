using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GP.UI.Portal.Controllers
{
    public class BaseController : Controller
    {
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
            if (Session["loginInfo"] == null)
            {
                //filterContext.HttpContext.Response.Redirect("/Login/Index");
               filterContext.Result = Redirect("/Login/Index");
                //filterContext.HttpContext.Response.Write("<script type='text/javascript'> window.top.location.href='/Login/Index';</script>");
            }
        }

    }
}
