using Microsoft.AspNetCore.Mvc;
using ScapeRoom.Models;

namespace ScapeRoom.Controllers;

public class HomeController : Controller
{


        public ActionResult Index()
        {
            return View();
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
    public IActionResult ResolverHabitacion(int sala, string clave){
        bool resolvio = false;
        if(sala == 1){
            resolvio = escape.ResolverSala1(sala, clave);
        }else{
            resolvio = escape.ResolverSala(sala, clave);
        }
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
