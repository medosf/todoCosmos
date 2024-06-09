using Microsoft.AspNetCore.Mvc;
namespace TodoComos.Controllers;

public class HomeController : Controller{
 [HttpGet]
public IActionResult Index()
{
    ViewData["Message"] = "Hello world!";

    return View();
}
}




