using DatabaseSessionState.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DatabaseSessionState.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            HttpContext.Session.SetString("Name", "Vahid Farahmandian");
            HttpContext.Session.SetString("TimeStamp", DateTime.Now.ToString());
            return View();
        }

        public IActionResult Privacy()
        {
            ViewBag.data = HttpContext.Session.GetString("Name") + HttpContext.Session.GetString("TimeStamp");
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}