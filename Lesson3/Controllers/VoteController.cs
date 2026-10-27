using Microsoft.AspNetCore.Mvc;

namespace Lesson3.Controllers;

public class VoteController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult VoteResult()
    {
        return View();
    }
}
