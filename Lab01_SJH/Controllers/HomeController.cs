using Lab01_SJH.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Lab01_SJH.Controllers
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
            return View();
        }
       void buscarlista(ref List<Player> lista) {
            string nombre;
            Console.WriteLine("Nombre");
            nombre=Console.ReadLine();
            bool encontrado = false;

            foreach(Player player in lista) 
            {
                if(nombre==player.Name)
                {
                    encontrado = true;
                }
            }
            if(encontrado)
            {
                Console.WriteLine("Si está");
            }
            else
            {
                Console.WriteLine("No está");
            }
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