using Microsoft.AspNetCore.Mvc;

namespace Lab01_SJH.Controllers
{
    public class PlayerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
