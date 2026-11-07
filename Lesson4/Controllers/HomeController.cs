using Lesson4.Data;
using Lesson4.Models;
using Lesson4.Validation;
using Microsoft.AspNetCore.Mvc;

namespace Lesson4.Controllers;

public class HomeController : Controller
{
    private IRepository _repository;

    public HomeController(IRepository repository)
    {
        _repository = repository;
    }

    private const int CountElementsOnPage = 20;

    public async Task<IActionResult> Index(RequestIndexModel indexModel)
    {
        if (indexModel?.SearchString != null)
        {
            indexModel.SearchString = indexModel.SearchString.Trim();
        }

        var allCounteElementsOnPage = _repository.GetCount(indexModel.SearchString);

        var responceIndexModel = new ResponceIndexModel<Cat>(
            indexModel.SearchString,
            indexModel.Page,
            allCounteElementsOnPage,
            CountElementsOnPage);

        if (indexModel.Page > responceIndexModel.TotalPages || indexModel.Page < 1)
        {
            return NotFound();
        }

        var countSkip = CountElementsOnPage * (responceIndexModel.CurrentPage - 1);

        List<Cat>? cats;
        if (indexModel != null && !string.IsNullOrEmpty(indexModel.SearchString))
        {
            cats = _repository.Filtered(indexModel.SearchString, countSkip, CountElementsOnPage);
        }
        else
        {
            cats = _repository.GetAllAsync(countSkip, CountElementsOnPage);
        }

        responceIndexModel.Pets = cats;

        return View(responceIndexModel);
    }

    public IActionResult Details(int id)
    {
        var isFavorite = _repository.IsFavorite(id);
        var cat = _repository.GetById(id);

        if (cat == null)
        {
            //HTTP -> 404 
            return NotFound();    
        }

        var favoriteCatPage = new FavoriteCatPage
        {
            IsFavorite = isFavorite,
            Cat = cat
        };

        return View(favoriteCatPage);
    }

    [HttpGet]
    public IActionResult Add()
    {
        var addCatPage = new AddCatPage
        {
            Cat = new Cat(),
            ValidationAddCat = new ValidationAddCat()
        };
        
        return View(addCatPage);
    }

    [HttpGet]
    public IActionResult Delete(int id)
    {
        var cat = _repository.GetById(id);

        return View(cat);
    }

    [HttpGet]
    public IActionResult Edit(int id)
    {
        var cat = _repository.GetById(id);

        return View(cat);
    }

    [HttpPost]
    public IActionResult Edit(Cat cat)
    {
        _repository.Update(cat);

        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    public IActionResult ConfirmDelete(int id)
    {
        _repository.Remove(id);

        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    public IActionResult Add(Cat cat)
    {
        var addCatPage = new AddCatPage
        {
            Cat = cat,
            ValidationAddCat = new ValidationAddCat()
        };

        if (cat.Age < 0)
        {
            addCatPage.ValidationAddCat.IncorrectAge = "Возраст не может быть меньше 0";
        }

        if (cat.Name.Length > 300)
        {
            addCatPage.ValidationAddCat.IncorrectName = "Имя котика не может быть свыше 300 символов";
        }

        if (addCatPage.ValidationAddCat.IncorrectName?.Length > 0 || 
            addCatPage.ValidationAddCat.IncorrectAge?.Length > 0)
        {
            return View(addCatPage);
        }

        _repository.Add(cat);

        return RedirectToAction(nameof(Index));
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
