using Lesson4.Data;
using Lesson4.Models;
using Lesson4.Services;
using Lesson4.Validation;
using Microsoft.AspNetCore.Mvc;

namespace Lesson4.Controllers;

public class HomeController : Controller
{
    private CatService _catService;

    public HomeController(CatService catService)
    {
        _catService = catService;
    }

    //Единая ответственность
    //S                                                                        OLID
    //1. 
    public async Task<IActionResult> Index(RequestIndexModel indexModel)
    {
        try
        {
            var responceIndexModel = await _catService.GetCatsAsync(indexModel);

            return View(responceIndexModel);
        }
        catch (ArgumentOutOfRangeException ex)
        {
            //Запись в лог ();

            return NotFound();
        }
        catch (Exception ex)
        {

            //пишем в лог о проблемах не входными данные
            return NotFound();
        }
    }

    //public IActionResult Details(int id)
    //{
    //    var isFavorite = _repository.IsFavorite(id);
    //    var cat = _repository.GetById(id);

    //    if (cat == null)
    //    {
    //        //HTTP -> 404 
    //        return NotFound();    
    //    }

    //    var favoriteCatPage = new FavoriteCatPage
    //    {
    //        IsFavorite = isFavorite,
    //        Cat = cat
    //    };

    //    return View(favoriteCatPage);
    //}

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

    //[HttpGet]
    //public IActionResult Delete(int id)
    //{
    //    var cat = _repository.GetById(id);

    //    return View(cat);
    //}

    //[HttpGet]
    //public IActionResult Edit(int id)
    //{
    //    var cat = _repository.GetById(id);

    //    return View(cat);
    //}

    //[HttpPost]
    //public IActionResult Edit(Cat cat)
    //{
    //    _repository.Update(cat);

    //    return RedirectToAction(nameof(Index));
    //}

    //[HttpPost]
    //public IActionResult ConfirmDelete(int id)
    //{
    //    _repository.Remove(id);

    //    return RedirectToAction(nameof(Index));
    //}

    //[HttpPost]
    //public IActionResult Add(Cat cat)
    //{
    //    var addCatPage = new AddCatPage
    //    {
    //        Cat = cat,
    //        ValidationAddCat = new ValidationAddCat()
    //    };

    //    if (cat.Age < 0)
    //    {
    //        addCatPage.ValidationAddCat.IncorrectAge = "Возраст не может быть меньше 0";
    //    }

    //    if (cat.Name.Length > 300)
    //    {
    //        addCatPage.ValidationAddCat.IncorrectName = "Имя котика не может быть свыше 300 символов";
    //    }

    //    if (addCatPage.ValidationAddCat.IncorrectName?.Length > 0 || 
    //        addCatPage.ValidationAddCat.IncorrectAge?.Length > 0)
    //    {
    //        return View(addCatPage);
    //    }

    //    _repository.Add(cat);

    //    return RedirectToAction(nameof(Index));
    //}

    //public IActionResult AddFavorite(int id)
    //{
    //    _repository.AddFavorite(id);

    //    return RedirectToAction(nameof(Details), new { id });
    //}

    //public IActionResult RemoveFavorite(int id)
    //{
    //    _repository.RemoveFavorite(id);

    //    return RedirectToAction(nameof(Details), new { id });
    //}
}
