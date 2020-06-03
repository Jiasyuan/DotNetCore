using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.UI;
using Microsoft.Extensions.DependencyInjection;

namespace Framework.MVC5MSDI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //«Ø¥ßServiceCollection
            var services = new ServiceCollection();
            ConfigureServices(services);
        }

        private void ConfigureServices(ServiceCollection services)
        {
            throw new NotImplementedException();
        }
    }
}
