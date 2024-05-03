using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebServicesAndEntityLinking.Models;

namespace WebServicesAndEntityLinking.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger /*RecordContext recordContext*/)
        {
            _logger = logger;
            //recordContext = new RecordContext();
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create()
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