using Lesson8.Data;
using Lesson8.Exceptions;
using Lesson8.Model;
using Lesson8.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Lesson8.Repositories;

public class ProductRepository(StoreDbContext storeDbContext) : IProductRepository
{
    public async Task<List<Product>> GetAllAsync()
    {
        var products = await storeDbContext.Products.AsNoTracking().ToListAsync();

        return products;
    }

    public async Task<Product> GetByIdAsync(Guid id)
    {
        var product = await storeDbContext.Products.FirstOrDefaultAsync(product => product.Id == id) ?? 
            throw new NotFoundException($"Объект {nameof(Product)} с Id = {id} не был найден");

        return product;
    }

    public async Task CreateAsync(Product product)
    {
        await storeDbContext.AddAsync(product);
        await storeDbContext.SaveChangesAsync();
    }

    public async Task RemoveAsync(Guid id)
    {
        var product = await GetByIdAsync(id);

        storeDbContext.Remove(product);
        await storeDbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(Product product)
    {
        var updatingProduct = await GetByIdAsync(product.Id);

        updatingProduct.Name = product.Name;
        updatingProduct.Description = product.Description;
        updatingProduct.Price = product.Price;

        await storeDbContext.SaveChangesAsync();
    }
}