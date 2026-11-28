using Lesson8.Exceptions;
using Lesson8.Model;
using Lesson8.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace Lesson8.Controllers;

/// <summary>
/// Контроллер для управления товарами.
/// Предоставляет REST API для CRUD-операций над сущностью <see cref="Product"/>.
/// </summary>
[ApiController]
[Route("[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class ProductController(IProductRepository productRepository) : ControllerBase
{
    /// <summary>
    /// Получить список всех товаров.
    /// </summary>
    /// <remarks>
    /// Пример запроса:
    ///
    ///     GET /Product
    ///
    /// </remarks>
    /// <returns>Коллекция всех товаров.</returns>
    /// <response code="200">Список товаров успешно получен.</response>
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<Product>), StatusCodes.Status200OK)]
    public async Task<IEnumerable<Product>> GetAll()
    {
        return await productRepository.GetAllAsync();
    }

    /// <summary>
    /// Получить товар по его идентификатору.
    /// </summary>
    /// <param name="id">Уникальный идентификатор (GUID) товара.</param>
    /// <returns>Найденный товар.</returns>
    /// <response code="200">Товар найден и возвращён.</response>
    /// <response code="404">Товар с указанным идентификатором не найден.</response>
    /// <response code="400">Некорректный запрос.</response>
    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(Product), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Product>> GetById(Guid id)
    {
        try
        {
            return await productRepository.GetByIdAsync(id);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
        catch (Exception)
        {
            return BadRequest();
        }
    }

    /// <summary>
    /// Создать новый товар.
    /// </summary>
    /// <param name="product">Данные создаваемого товара.</param>
    /// <returns>Результат операции создания.</returns>
    /// <response code="201">Товар успешно создан.</response>
    /// <response code="400">Некорректные данные товара.</response>
    [HttpPost]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> Create([FromBody] Product product)
    {
        try
        {
            await productRepository.CreateAsync(product);
        }
        catch (Exception)
        {
            return BadRequest();
        }

        return Created();
    }

    /// <summary>
    /// Обновить существующий товар.
    /// </summary>
    /// <param name="product">Товар с обновлёнными данными (должен содержать существующий Id).</param>
    /// <returns>Результат операции обновления.</returns>
    /// <response code="204">Товар успешно обновлён.</response>
    /// <response code="404">Товар с указанным идентификатором не найден.</response>
    [HttpPut]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> Update([FromBody] Product product)
    {
        try
        {
            await productRepository.UpdateAsync(product);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
        catch (Exception)
        {
            return BadRequest();
        }

        return NoContent();
    }

    /// <summary>
    /// Удалить товар по идентификатору.
    /// </summary>
    /// <param name="id">Уникальный идентификатор (GUID) товара.</param>
    /// <returns>Результат операции удаления.</returns>
    /// <response code="204">Товар успешно удалён.</response>
    /// <response code="404">Товар с указанным идентификатором не найден.</response>
    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> Remove(Guid id)
    {
        try
        {
            await productRepository.RemoveAsync(id);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
        catch (Exception)
        {
            return BadRequest();
        }

        return NoContent();
    }
}