﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace MVC_VB2
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            //Standaard
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            // Application State
            Application.Lock();
            Application.Add("aantalBezoeken", 0);
            Application.UnLock();

            // Resources in nederlands
            DefaultModelBinder.ResourceClassKey = "Messages";
        }

        protected void Session_Start()
        {
            Session["aantalBezoeken"] = 0;
        }
    }
}
