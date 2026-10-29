using Lesson4.Data;
using Lesson4.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lesson4.Controllers;

public class HomeController : Controller
{
    private static Repository _repository;

    public HomeController(Repository repository)
    {
        _repository = repository;
    }

    public IActionResult Index()
    {
        var cats = _repository.GetAll();

        return View(cats);
    }

    public IActionResult Details(int id)
    {
        var isFavorite = _repository.IsFavorite(id);
        var cat = _repository.GetById(id);

        var favoriteCatPage = new FavoriteCatPage
        {
            IsFavorite = isFavorite,
            Cat = cat
        };

        return View(favoriteCatPage);
    }

    public IActionResult AddFavorite(int id)
    {
        _repository.AddFavorite(id);

        return RedirectToAction(nameof(Details), new { id });
    }

    public IActionResult RemoveFavorite(int id)
    {
        _repository.RemoveFavorite(id);

        return RedirectToAction(nameof(Details), new { id });
    }
}
