using System.Linq;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
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

            //�إ�ServiceCollection
            var services = new ServiceCollection();
            ConfigureServices(services);

            //�ۭqResolver
            var resolver = new CoreDIDependencyResolver(services.BuildServiceProvider());
            DependencyResolver.SetResolver(resolver);
        }

        private void ConfigureServices(ServiceCollection services)
        {
            //��X�Ҧ���Controller
            var controllers = typeof(MvcApplication).Assembly.GetExportedTypes()//�Ҧ�public class
                            .Where(t => !t.IsAbstract)//�D��H���O
                            .Where(t => typeof(IController).IsAssignableFrom(t))//�~��IController
                            .Where(t => t.Name.EndsWith("Controller"))//�W�٥HController����
                            .ToList();
            //�NController�[�JServiceCollection
            controllers.ForEach(ctrl => services.AddTransient(ctrl));
            //���UHttpClient
            services.AddHttpClient();
        }
    }
}
