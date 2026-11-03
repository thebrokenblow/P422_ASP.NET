using Lesson4.Models;

namespace Lesson4.Data;

public interface IRepository
{
    List<Cat> GetAll();

    Cat? GetById(int id);

    bool IsFavorite(int id);

    void Add(Cat cat);

    void AddFavorite(int id);

    void RemoveFavorite(int id);

    void Remove(int id);

    void Update(Cat cat);
}