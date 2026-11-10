using System.ComponentModel.DataAnnotations;

namespace Lesson6.Models;

public class ProductEdit
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }

    [Display(Name = "File")]
    public IFormFile PhotoFile { get; set; }

    public byte[]? PhotoBytes { get; set; }   // текущее фото
    public string? PhotoFileName { get; set; }
}
