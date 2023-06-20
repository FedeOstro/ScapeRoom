using Microsoft.AspNetCore.Mvc;
using ScapeRoom.Models;

namespace ScapeRoom.Controllers;

public class HomeController : Controller
{
      private Maze maze;
       public HomeController()
        {
            // Inicializar la instancia de Maze en el constructor
            maze = new Maze(15, 10);
            maze.GenerateMaze();
        }
        public ActionResult Index()
        {
            return View();
        }

      public ActionResult Habitacion1()
        {
           return View("habitacion1", maze); // Pasar la instancia de Maze a la vista "habitacion1.cshtml"
        }
    public IActionResult Tutorial(){
        return View();
    }

    public IActionResult comenzar(){
        return View();
    }

    public IActionResult creditos(){
        return View();
    }

    public IActionResult Habitacion(int NumSala){
        return View("Habitacion"+NumSala);
    }
    [HttpPost]
        public ActionResult CheckCollision(int row, int col)
        {
            bool collision = maze.CheckCollision(row, col);
            return Json(new { collision });
        }
        [HttpPost]
        public ActionResult CheckEnd(int row, int col)
        {
            bool end = maze.CheckEnd(row, col);
            return Json(new { end });
        }

        [HttpPost]
    public IActionResult ResolverHabitacion(int sala, string clave){
        bool resolvio = escape.ResolverSala(sala, clave);
        if(resolvio == true){
            return View("rta"+sala);
        }else{
            return View("Habitacion"+sala);
        }
        
    }
    public IActionResult salafinal(int sala ,int num1, int num2, int num3, int num4){
        string numerosCombinados = num1.ToString() + num2.ToString() + num3.ToString() + num4.ToString();
        bool resolvio = escape.ResolverSala(sala, numerosCombinados);
        if(resolvio == true){
            return View("victoria");
        }else{
            return View("Habitacion"+sala);
        }
    }

}
