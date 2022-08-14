using Front_Tarea3.Helpers;
using Front_Tarea3.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Front_Tarea3.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IProtectionRoutesService _protectionRoute;

        public HomeController(ILogger<HomeController> logger, IProtectionRoutesService protectionRoute)
        {
            _protectionRoute = protectionRoute;
            _logger = logger;
        }

        public IActionResult Index()
        {
            

             return View();
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