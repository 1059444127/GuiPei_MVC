﻿using System.Web.Mvc;

namespace GP.UI.Portal.Areas.Students
{
    public class StudentsAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Students";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Students_default",
                "Students/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
