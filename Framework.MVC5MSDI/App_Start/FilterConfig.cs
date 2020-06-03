using System.Web;
using System.Web.Mvc;

namespace Framework.MVC5MSDI
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
