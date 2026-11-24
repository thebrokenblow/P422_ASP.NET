using Lesson8.Exceptions;
using Lesson8.Model;
using Lesson8.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Lesson8.Controllers;

[ApiController]
[Route("[controller]")]
//Обрабатывает запросы 
public class ProductController(IProductRepository productRepository) : ControllerBase
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
        return await productRepository.GetAllAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Product>> GetById(Guid id)
    {
        try
        {
            return await productRepository.GetByIdAsync(id);
        }
        catch (NotFoundException ex)
        {
            return NotFound();
        }
        catch (Exception ex)
        {
            return BadRequest();
        }
    }

    [HttpPost]
    public async Task<ActionResult> Create(Product product)
    {   
        try
        {
            await productRepository.CreateAsync(product);
        }
        catch (Exception ex)
        {
            
        }

        
        return Created();
    }

    [HttpPut]
    public async Task<ActionResult> Update(Product product)
    {
        try
        {
            await productRepository.UpdateAsync(product);
        }
        catch (NotFoundException ex)
        {
            return NotFound();
        }
        catch (Exception ex)
        {

        }

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Remove(Guid id)
    {
        try
        {
            await productRepository.RemoveAsync(id);
        }
        catch (NotFoundException ex)
        {
            return NotFound();
        }
        catch (Exception ex)
        {

        }

        return NoContent();
    }
}