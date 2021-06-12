using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using RoleBaseProject.Identity;
using System.Security.Principal;

namespace RoleBaseProject
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        public override void Init()
        {
            base.Init();
            PostAuthenticateRequest += new EventHandler(MvcApplication_PostAuthenticateRequest);
        }

        void MvcApplication_PostAuthenticateRequest(object sender, EventArgs e)
        {
            HttpCookie authCookie = Request.Cookies[FormsAuthentication.FormsCookieName];
            if (authCookie != null)
            {
                FormsAuthenticationTicket authTicket = FormsAuthentication.Decrypt(authCookie.Value);
                if (authTicket == null || authTicket.Expired)
                    return;

                //RoleBaseProject.Identity.Identity id = new RoleBaseProject.Identity.Identity(authTicket.Name, authTicket.UserData);
                //Principal user = new Principal(id);
                var user = HttpContext.Current.User;
                Context.User = user;
                Thread.CurrentPrincipal = user;
               
            }
        }
    }
}
