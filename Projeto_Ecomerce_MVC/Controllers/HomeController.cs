using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Projeto_Ecomerce_Biblioteca.Entidade;
using Projeto_Ecomerce_MVC.Models;
using System.Diagnostics;

namespace Projeto_Ecomerce_MVC.Controllers
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
           Amigo cliente = new Amigo();

            return View(cliente);
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
