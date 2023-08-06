using InfoTrackUkApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Unity;
using Unity.AspNet.Mvc;

namespace InfoTrackUkApp
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var container = new UnityContainer();
            container.RegisterType<WebScraperService>();
            container.RegisterType<DbService>();
            container.RegisterType<HtmlProcessService>();
            container.RegisterType<SearchEngineDecisionService>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));

        }
    }
}
