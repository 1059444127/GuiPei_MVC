﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GP.UI.Portal.Areas.Teachers.Controllers
{
    public class BaseTeachersController : Controller
    {
        //
        // GET: /Teachers/BaseTeachers/

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
            if (Session["loginInfo"] == null)
            {
                filterContext.HttpContext.Response.Write("<script type='text/javascript'> window.top.location.href='/Login/Index';</script>");
                //filterContext.Result = RedirectToAction("LoginIndex");
            }
        } 

    }
}
