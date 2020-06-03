using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using Microsoft.Extensions.Http;

namespace Framework.MVC5MSDI.Controllers
{
    public class HomeController : Controller
    {
        private readonly HttpClient httpClient;

        public HomeController(IHttpClientFactory httpClientFactory)
        {
            this.httpClient = httpClientFactory.CreateClient();
        }

        public ActionResult Index()
        {
            return View();
        }

        public async System.Threading.Tasks.Task<ActionResult> About()
        {
            var result = await httpClient.GetStringAsync("https://apiservice.mol.gov.tw/OdService/download/A17030000J-000047-cEE");
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