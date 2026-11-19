using Lesson8.Model;
using Microsoft.AspNetCore.Mvc;

namespace Lesson8.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductController : ControllerBase
{
    private static List<Product> Products =
        [
            new Product
            {
                Id = Guid.NewGuid(),
                Name = "IPhone 18 PRO MAX",
                Description = "Дорогой телефон",
                Price = 200_000
            },
            new Product
            {
                Id = Guid.NewGuid(),
                Name = "IPhone 18 PRO MAX",
                Description = "Дорогой телефон",
                Price = 200_000
            },
            new Product
            {
                Id = Guid.NewGuid(),
                Name = "IPhone 18 PRO MAX",
                Description = "Дорогой телефон",
                Price = 200_000
            },
            new Product
            {
                Id = Guid.NewGuid(),
                Name = "IPhone 18 PRO MAX",
                Description = "Дорогой телефон",
                Price = 200_000
            },
            new Product
            {
                Id = Guid.NewGuid(),
                Name = "IPhone 18 PRO MAX",
                Description = "Дорогой телефон",
                Price = 200_000
            },
            new Product
            {
                Id = Guid.NewGuid(),
                Name = "IPhone 18 PRO MAX",
                Description = "Дорогой телефон",
                Price = 200_000
            }
        ];

    /// <summary>
    /// HTTP Какие виды запросов? POST, GET, DELETE, PUT
    /// POST - создание ресурса на сервере (запись в бд)
    /// GET - получение данных из бд / файла
    /// DELETE - удаление данных
    /// PUT - обновление данных
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public IEnumerable<Product> Get()
    {
        return Products;
    }

    [HttpGet("{id}")]
    public Product Get(Guid id)
    {
        return Products.First(product => product.Id == id);
    }

    [HttpPost]
    public void Create(Product product)
    {
        Products.Add(product);
    }

    [HttpPut]
    public void Update(Product product)
    {
        var updatingProduct = Products.Where(product => product.Id == product.Id).First();

        updatingProduct.Name = product.Name;
        updatingProduct.Description = product.Description;
        updatingProduct.Price = product.Price;
    }

    [HttpDelete("{id}")]
    public void Remove(Guid id)
    {
        var product = Products.Where(product => product.Id == id).First();
        Products.Remove(product);
    }
}