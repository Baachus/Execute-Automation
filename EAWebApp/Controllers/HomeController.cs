using EAWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace EAWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index() => View();

        public IActionResult Privacy() => View();

        public IActionResult Demo() => View();

        public async Task<IActionResult> Product()
        {
            var productClient = new ProductAPI("http://eaapi:8001", new HttpClient());

            var result = await productClient.GetProductsAsync();

            return View(result);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}