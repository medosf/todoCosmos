using Microsoft.AspNetCore.Mvc;
namespace TodoCosmos.Controllers;

public class HomeController : Controller{
 [HttpGet]
public IActionResult Index()
{
    ViewData["Message"] = "Hello world!";

    return View();
}
}




