using System.Net.Http;
using System.Web.Mvc;
using Microsoft.Extensions.Logging;

namespace Framework.MVC5MSDI.Controllers
{
    public class HomeController : Controller
    {
        private readonly HttpClient httpClient;
        private readonly ILogger<HomeController> logger;

        public HomeController(IHttpClientFactory httpClientFactory, ILogger<HomeController> logger)
        {
            this.httpClient = httpClientFactory.CreateClient();
            this.logger = logger;
        }

        public ActionResult Index()
        {
            return View();
        }

        public async System.Threading.Tasks.Task<ActionResult> About()
        {
            var result = await httpClient.GetStringAsync("https://apiservice.mol.gov.tw/OdService/download/A17030000J-000047-cEE");
            logger.LogDebug(result);
            ViewBag.Message = result;

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}