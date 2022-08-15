using AnnexioLuke.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using AnnexioLuke.Services;

namespace AnnexioLuke.Controllers
{
    public class HomeController : Controller
    {

        [ResponseCache(Duration = 10, Location = ResponseCacheLocation.None, NoStore = true)]
        public async Task<ActionResult> Index()
        {

            List<Countries> CountryInfo = new List<Countries>();
       
            return View(CountryInfo);
        }

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

     

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 10, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}