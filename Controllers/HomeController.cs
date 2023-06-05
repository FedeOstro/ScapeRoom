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

    public IActionResult Comenzar(){
        return View();
    }

    public IActionResult Habitacion(int sala, string clave){
        return View();
    }


}
