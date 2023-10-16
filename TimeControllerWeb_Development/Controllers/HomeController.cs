using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Diagnostics;
using System.Threading.Tasks;
using InventoryControllerWeb_Development.Factory;
using InventoryControllerWeb_Development.Models;

namespace InventoryControllerWeb_Development.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private string apiBaseUrl;

        public HomeController(ILogger<HomeController> logger, IOptions<MySettingsModel> myConfiguration)
        {
            _logger = logger;
            MyConfiguration.WebApiBaseUrl = myConfiguration.Value.WebApiBaseUrl;
        }

        public async Task<IActionResult> Index()
        {
            ////var model = new ProjectViewModel();
            //using (HttpClient client = new HttpClient())
            //{
            //    client.BaseAddress = new Uri(apiBaseUrl);
            //    MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("*/*");
            //    client.DefaultRequestHeaders.Accept.Add(contentType);
            //    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoiYWxwZXNoIiwianRpIjoiYTIxMGU5N2YtNzMxZi00ZTJjLWIyNWItOTZjMTcxZGE3MDRkIiwiZXhwIjoxNjE1MjE2MDMxLCJpc3MiOiJodHRwczovL2Rldi10ZWNoc3RyZW0udXMuYXV0aDAuY29tIiwiYXVkIjoiaHR0cHM6Ly9sb2NhbGhvc3Q6NDQzMDQifQ.nMXLarIFUy06Ly4AcnNalUuzXFslCoMD8dLmvEL7u34");

            //    HttpResponseMessage response = client.GetAsync("/api/Home").Result;
            //    string stringData = response.Content.ReadAsStringAsync().Result;

            //    return View();
            //}
            var data = await APIClientFactory.Instance.CheckAuthorize(MyConfiguration.Token);
            if (data.Message == "Success")
                return View();
            else
            {
                return RedirectToAction("login", "Account");
            }
            //return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
