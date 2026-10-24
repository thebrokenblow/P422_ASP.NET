using Lesson2.Data;
using Microsoft.AspNetCore.Mvc;

namespace Lesson2.Controllers;

public class HomeController : Controller
{
    private Repository _repository;
    public HomeController(Repository repository)
    {
        _repository = repository;
    }

    public IActionResult Index()
    {
        var cats = _repository.GetAll();
        return View(cats);
    }
}
