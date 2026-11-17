using Lesson7.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Lesson7.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            //из бд получаю данные

            var person = new Person
            {
                FirstName = "Иван",
                LastName = "Иванов",
                Age = 32,
            };

            var persons = new List<Person>
            {
                person,
                person,
                person,
                person,
                person,
                person,
                person,
                person,
                person,
                person,
                person,
                person,
                person,
                person,
                person,
                person,
                person,
                person,
                person,
                person,
                person,
                person,
                person,
                person
            };

            return View(persons);
        }

        public IActionResult Privacy()
        {
            var person = new Person
            {
                FirstName = "Иван",
                LastName = "Иванов",
                Age = 32,
            };

            var persons = new List<Person>
            {
                person,
                person,
                person,
                person,
                person,
                person,
                person,
                person,
                person,
                person,
                person,
                person,
                person,
                person,
                person,
                person,
                person,
                person,
                person,
                person,
                person,
                person,
                person,
                person
            };

            return View(persons);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Details()
        {
            return View();
        }

        public IActionResult Info()
        {
            return View();
        }
    }
}
