using Lab01_SJH.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lab01_SJH.Controllers
{
    public class PlayerController : Controller
    {
        List<Player> playersList = new List<Player>();

        public IActionResult Index()
        {
            List<Teams> teamsList = new List<Teams>();
            List<Player> playersList = new List<Player>();

            // Ejemplo incerscion manual
            playersList.Add(new Player()
            {
                Name = "Faker",
                LName = "GoJeonPa",
                Team = "T1",
                Rol = "mid-laner",
                KDA = 4.3,
                CS = 846
            });

            return View();
        }

        [Route("SubirArchivo")]
        public IActionResult subirArchivos()
        {
            return View();
        }


        [HttpPost("SubirArchivo")]
        public IActionResult subirArchivos(IFormFile file)
        {
            if (file != null)
            {
                try
                {
                    string ruta = Path.Combine(Path.GetTempPath(), file.Name);
                    using (var stream = new FileStream(ruta, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                    string allFileData = System.IO.File .ReadAllText(ruta);
                    foreach (string lineaActual in allFileData.Split('\n'))
                    {
                        if (!string.IsNullOrEmpty(lineaActual))
                        {
                            string[] informacion = lineaActual.Split(',');
                            var player = new Player();
                            player.Name = informacion[0];
                            player.LName = informacion[1];
                            player.Team = informacion[2];
                            player.Rol = informacion[3];
                            player.KDA = Convert.ToDouble(informacion[4]);
                            player.CS = Convert.ToInt32(informacion[5]);
                            playersList.Add(player);
                        }
                    }
                }
                catch (Exception e)
                {

                    ViewBag.Error = e.Message;
                }
            }
            return View(playersList);
        }
    }
}
