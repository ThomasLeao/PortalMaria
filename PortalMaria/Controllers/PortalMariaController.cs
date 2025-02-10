using Microsoft.AspNetCore.Mvc;
using PortalMaria.Models;
using System.Diagnostics;

namespace PortalMaria.Controllers
{
    public class PortalMariaController : Controller
    {
        private readonly ILogger<PortalMariaController> _logger;

        public PortalMariaController(ILogger<PortalMariaController> logger)
        {
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
