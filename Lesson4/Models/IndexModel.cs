namespace Lesson4.Models;

public class IndexModel<T>
{
    public required List<T> Pets { get; set; }
    public required string SearchString { get; set; }
    public required int Page { get; set; }

    private readonly int totalPages;

    public IndexModel(int allCountObjects, int pageSize)
    {
        totalPages = (int)Math.Ceiling(allCountObjects / (double)pageSize);
    }

    public bool HasPreviousPage => Page > 1;
    public bool HasNextPage => Page < totalPages;
}