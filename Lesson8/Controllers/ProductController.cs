using Lesson8.Data;
using Lesson8.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lesson8.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductController(StoreDbContext context) : ControllerBase
{
    /// <summary>
    /// HTTP Какие виды запросов? POST, GET, DELETE, PUT
    /// (200) - Запрос был успешен (оперции чтения), Обновлении
    /// (201) - По запросу успешно создан ресурс
    /// (204) - При удалении 
    /// 
    /// 404 - Ресурс не был найден (когда объекта не будет в бд)
    /// 400 - Bad Request 
    /// 
    /// POST - создание ресурса на сервере (запись в бд)
    /// GET - получение данных из бд / файла
    /// DELETE - удаление данных
    /// PUT - обновление данных
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<IEnumerable<Product>> GetAll()
    {
        return await context.Products.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Product>> GetById(Guid id)
    {
        var product = await context.Products.FirstOrDefaultAsync(product => product.Id == id);

        if (product == null)
        {
            return NotFound();
        }

        return product;
    }

    [HttpPost]
    public async Task<ActionResult> Create(Product product)
    {
        //Валидация

        //return BadRequest();
        return Created();

        await context.AddAsync(product);
        await context.SaveChangesAsync();
    }

    [HttpPut]
    public void Update(Product product)
    {
        //Валидация

        //return BadRequest();
        var updatingProduct = context.Products.Where(product => product.Id == product.Id).First();

        updatingProduct.Name = product.Name;
        updatingProduct.Description = product.Description;
        updatingProduct.Price = product.Price;

        //return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Remove(Guid id)
    {
        var product = await context.Products.FirstOrDefaultAsync(product => product.Id == id);

        if (product == null)
        {
            return NotFound();
        }

        context.Remove(product);
        await context.SaveChangesAsync();

        return NoContent();
    }
}