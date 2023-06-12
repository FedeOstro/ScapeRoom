using Microsoft.AspNetCore.Mvc;

namespace ScapeRoom.Controllers;

public class HomeController : Controller
{
    public IActionResult Index(){
        
        return View();
    }

    public IActionResult Tutorial(){
        return View();
    }

    public IActionResult comenzar(){
        return View();
    }

    public IActionResult Habitacion(int NumSala){
        return View("Habitacion"+NumSala);
    }
    public IActionResult ResolverHabitacion(int sala, string clave){
        if(sala == escape.GetEstadoJuego()){
            if(escape.ResolverSala(sala,clave) == true){
                return View("habitacion+escape.GetEstadoJuego()");
                if(sala == 4){
                    return View("Victoria");
                }
            }else{
                return View("habitacion+escape.GetEstadoJuego()");
                ViewBag.Error = "La clave ingresada es incorrecta";
            }
        }else{
            return View("habitacion+escape.GetEstadoJuego()");
        }
        
    }


}
