using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.UI;
using Framework.MVC5MSDI.Resolver;
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

            //建立ServiceCollection
            var services = new ServiceCollection();
            ConfigureServices(services);

            //自訂Resolver
            var resolver = new CoreDIDependencyResolver(services.BuildServiceProvider());
            DependencyResolver.SetResolver(resolver);
        }

        private void ConfigureServices(ServiceCollection services)
        {
            //找出所有的Controller
            var controllers = typeof(MvcApplication).Assembly.GetExportedTypes()//所有public class
                            .Where(t => !t.IsAbstract)//非抽象類別
                            .Where(t => typeof(IController).IsAssignableFrom(t))//繼承IController
                            .Where(t => t.Name.EndsWith("Controller"))//名稱以Controller結尾
                            .ToList();
            //將Controller加入ServiceCollection
            controllers.ForEach(ctrl => services.AddTransient(ctrl));
            //加入HttpClient
            services.AddHttpClient();
        }
    }
}
