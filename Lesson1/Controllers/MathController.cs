using Lesson1.Model;
using Microsoft.AspNetCore.Mvc;

namespace Lesson1.Controllers;

public class MathController : Controller
{
    public IActionResult Plus(int a, int b)
    {
        var service = new Service(new RepositoryNoSql());
        service.Order();

        var mathPlus = new MathPlus(a, b);
        return View(mathPlus);
    }
}

/// <summary>
/// Класс который отвечает за обработку заказа
/// </summary>
class Service
{
    private readonly IRepository _repository;

    public Service(IRepository repository)
    {
        _repository = repository;
    }

    public void Order(/*params*/)
    {
        _repository.Select();
        //Создать заказ в бд
        //Поменять статус заказа
        //Отправить ответ клиенту, о том что заказ создан
        //...
    }
}

public interface IRepository
{
    public void Add();

    public void Delete();

    public void Select();
}

/// <summary>
/// Класс который взаимодействует с бд
/// </summary>
public class RepositorySql : IRepository
{
    public void Add()
    {
        
    }

    public void Delete()
    {

    }

    public void Select()
    {

    }
}

/// <summary>
/// Класс который взаимодействует с бд
/// </summary>
public class RepositoryNoSql : IRepository
{
    public void Add()
    {

    }

    public void Delete()
    {

    }

    public void Select()
    {

    }
}