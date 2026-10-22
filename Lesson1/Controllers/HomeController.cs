using Microsoft.AspNetCore.Mvc;

namespace Lesson1.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        // IActionResult -> web - страница (html + css + js)
        // return View(); 
        // View -> Home -> Index

        return View();
    }
}
