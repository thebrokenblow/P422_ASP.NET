
using Lesson6.Data;
using Lesson6.Models;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lesson6.Controllers;

public class ProductsController : Controller
{
    private readonly ProductDbContext _context;

    public ProductsController(ProductDbContext context)
    {
        _context = context;
    }

    // GET: PRODUCTS
    public async Task<IActionResult> Index()
    {
        return View(await _context.Products.ToListAsync());
    }

    // GET: PRODUCTS/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var product = await _context.Products
            .FirstOrDefaultAsync(m => m.Id == id);

        //Convert byte arry to base64string   
        string imreBase64Data = Convert.ToBase64String(product.PhotoBytes);
        string imgDataURL = string.Format("data:image/png;base64,{0}", imreBase64Data);
        //Passing image data in viewbag to view  

        var productDetails = new ProductDetails
        {
            Id = product.Id,
            Name = product.Name,
            Description = product.Description,
            Price = product.Price,
            PhotoUrl = imgDataURL,
        };

        if (product == null)
        {
            return NotFound();
        }

        return View(productDetails);
    }

    // GET: PRODUCTS/Create
    public IActionResult Create()
    {
        var productCreate = new ProductCreate();
        return View(productCreate);
    }

    [HttpPost]
    public async Task<IActionResult> Create(ProductCreate productCreate)
    {
        string fileName = Path.GetFileName(productCreate.PhotoFile.FileName);
        using var ms = new MemoryStream();
        productCreate.PhotoFile.CopyTo(ms);
        var arrayBytes = ms.ToArray();

        var product = new Product
        {
            Name = productCreate.Name,
            Description = productCreate.Description,
            Price = productCreate.Price,
            PhotoBytes = ms.ToArray()
        };

        await _context.AddAsync(product);
        await _context.SaveChangesAsync();

        return RedirectToAction(nameof(Index));
    }

    // GET: PRODUCTS/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var product = await _context.Products.FindAsync(id);
        if (product == null)
        {
            return NotFound();
        }

        var stream = new MemoryStream(product.PhotoBytes);
        IFormFile file = new FormFile(stream, 0, product.PhotoBytes.Length, "name", "fileName");

        var productEdit = new ProductEdit
        {
            Id = product.Id,
            Name = product.Name,
            Description = product.Description,
            Price = product.Price,
            PhotoFile = file,
            PhotoFileName = "test.img",
            PhotoBytes = product.PhotoBytes
        };

        return View(productEdit);
    }

    // POST: Products/Edit/5
    [HttpPost]
    public async Task<IActionResult> Edit(int? id, ProductEdit productEdit)
    {
        using var ms = new MemoryStream();
        var product = await _context.Products.FirstAsync(x => x.Id == productEdit.Id);

        product.Name = productEdit.Name;
        product.Description = productEdit.Description;
        product.Price = productEdit.Price;

        if (productEdit.PhotoFile is not null)
        {
            await productEdit.PhotoFile.CopyToAsync(ms);
            product.PhotoBytes = ms.ToArray();
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    // GET: PRODUCTS/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var product = await _context.Products
            .FirstOrDefaultAsync(m => m.Id == id);
        if (product == null)
        {
            return NotFound();
        }

        return View(product);
    }

    // POST: PRODUCTS/Delete/5
    [HttpPost, ActionName("Delete")]
    public async Task<IActionResult> DeleteConfirmed(int? id)
    {
        var product = await _context.Products.FindAsync(id);
        if (product != null)
        {
            _context.Products.Remove(product);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool ProductExists(int? id)
    {
        return _context.Products.Any(e => e.Id == id);
    }
}