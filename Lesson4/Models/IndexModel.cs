namespace Lesson4.Models;

public class IndexModel<T>
{
    public required List<T> Pets { get; set; }
    public required string SearchString { get; set; }
}
