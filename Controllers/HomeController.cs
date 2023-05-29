using Microsoft.AspNetCore.Mvc;

namespace ScapeRoom.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
