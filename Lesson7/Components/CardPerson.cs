using Lesson7.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lesson7.Components;

public class CardPerson : ViewComponent
{
    public IViewComponentResult Invoke(Person person)
    {
        //Логика форматирования входных данных для отображения 

        return View("PersonInfo",  person);
    }
}
