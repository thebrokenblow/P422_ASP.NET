using Lesson7.Models;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace Lesson7.Components;

public class CardPerson : ViewComponent
{
    public IViewComponentResult Invoke(Person person, string name, string description, string controllerName, string actionName)
    {
        var cardDetails = new CardDetails
        {
            Person = person,
            ControllerName = controllerName,
            ActionName = actionName
        };

        //Логика форматирования входных данных для отображения 

        return View("PersonInfo", cardDetails);
    }
}
