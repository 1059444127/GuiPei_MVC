using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Compilation;
using System.Web.Routing;

namespace GP.UI.Portal.Common
{
    public class WebFormsRouteHandler:IRouteHandler
    {
        private string pageName = string.Empty;

        public WebFormsRouteHandler(string page)
        {
            this.pageName = page;
        }


        public IHttpHandler GetHttpHandler(RequestContext requestContext)
        {
            // 创建实例
            IHttpHandler hander = BuildManager.CreateInstanceFromVirtualPath("/WebForms/" + this.pageName, typeof(System.Web.UI.Page)) as IHttpHandler;

            return hander;
        }
    }
}