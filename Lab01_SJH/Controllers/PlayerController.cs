using Lab01_SJH.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lab01_SJH.Controllers
{
    [Route("[controller]")]
    public class PlayerController : Controller
    {
        List<Player> playersList = new List<Player>();
        List<Teams> teamsList = new List<Teams>();

        public IActionResult Index()
        {           
            List<Player> playersList = new List<Player>();

            // Ejemplo incerscion manual Player
            playersList.Add(new Player()
            {
                Name = "Faker",
                LName = "GoJeonPa",
                Team = "T1",
                Rol = "mid-laner",
                KDA = 4.3,
                CS = 846
            });

            List<Teams> teamsList = new List<Teams>();

            // Ejemplo incersion manual Teams
            teamsList.Add(new Teams()
            {
                TeamName = "T1",
                TeamCoach = "GBM",
                League = "League of Legends Champions Korea",
                CreationDate = "2003"
            });

            return View();
        }

    

        [Route("SubirArchivo")]
        public IActionResult SubirArchivo()
        {
            return View();
        }
        public IActionResult SubirArchivo()
        {
            return View();
        }


        [HttpPost("SubirArchivo")]
        public IActionResult SubirArchivo(IFormFile file)
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

        [Route("SubirArchivo2")]
        public IActionResult SubirArchivo2()
        {
            return View();
        }

        [HttpPost("SubirArchivo2")]
        public IActionResult SubirArchivo2(IFormFile file)
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
                    string allFileData = System.IO.File.ReadAllText(ruta);
                    foreach (string lineaActual in allFileData.Split('\n'))
                    {
                        if (!string.IsNullOrEmpty(lineaActual))
                        {
                            string[] informacion = lineaActual.Split(',');
                            var team = new Teams();
                            team.TeamName = informacion[0];
                            team.TeamCoach = informacion[1];
                            team.League = informacion[2];
                            team.CreationDate = informacion[3];
                            teamsList.Add(team);

                        }
                    }
                }
                catch (Exception e)
                {

                    ViewBag.Error = e.Message;
                }
            }
            return View(teamsList);
        }
    }
}
