using Lesson4.Models;

namespace Lesson4.Data;

public class Repository
{
    private static List<Cat> cats;
    private static List<int> favoriteCats = new();


    public Repository()
    {
        int i = 0;
        cats = new List<Cat>
        {
            new Cat
            {
                Id = ++i,
                Name = "Барсик",
                Age = 3,
                Color = "Рыжий",
                Description = "Ласковый и игривый кот, любит спать на подоконнике.",
                UrlPhoto = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTfy09fP9Yv1Z8PXwlPwALtee_kn-dDjYcpr4MozfTi1W4XSxp6yCNOR1w&s=10"
            },
            new Cat
            {
                Id = ++i,
                Name = "Мурка",
                Age = 2,
                Color = "Белый",
                Description = "Пушистая кошка с голубыми глазами, очень спокойная.",
                UrlPhoto = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTfy09fP9Yv1Z8PXwlPwALtee_kn-dDjYcpr4MozfTi1W4XSxp6yCNOR1w&s=10"
            },
            new Cat
            {
                Id = ++i,
                Name = "Васька",
                Age = 5,
                Color = "Серый",
                Description = "Опытный охотник, любит гулять на улице.",
                UrlPhoto = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTfy09fP9Yv1Z8PXwlPwALtee_kn-dDjYcpr4MozfTi1W4XSxp6yCNOR1w&s=10"
            },
            new Cat
            {
                Id = ++i,
                Name = "Снежок",
                Age = 1,
                Color = "Белый",
                Description = "Маленький котёнок, очень активный и любопытный.",
                UrlPhoto = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTfy09fP9Yv1Z8PXwlPwALtee_kn-dDjYcpr4MozfTi1W4XSxp6yCNOR1w&s=10"
            },
            new Cat
            {
                Id = ++i,
                Name = "Том",
                Age = 4,
                Color = "Чёрный",
                Description = "Независимый и умный кот, любит тишину.",
                UrlPhoto = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTfy09fP9Yv1Z8PXwlPwALtee_kn-dDjYcpr4MozfTi1W4XSxp6yCNOR1w&s=10"
            },
            new Cat
            {
                Id = ++i,
                Name = "Луна",
                Age = 2,
                Color = "Трёхцветная",
                Description = "Грациозная кошка, обожает внимание и ласку.",
                UrlPhoto = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTfy09fP9Yv1Z8PXwlPwALtee_kn-dDjYcpr4MozfTi1W4XSxp6yCNOR1w&s=10"
            },
            new Cat
            {
                Id = ++i,
                Name = "Леопольд",
                Age = 6,
                Color = "Полосатый",
                Description = "Добрый и мудрый кот, всегда сохраняет спокойствие.",
                UrlPhoto = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTfy09fP9Yv1Z8PXwlPwALtee_kn-dDjYcpr4MozfTi1W4XSxp6yCNOR1w&s=10"
            },
            new Cat
            {
                Id = ++i,
                Name = "Персик",
                Age = 1,
                Color = "Персидский",
                Description = "Пушистый котёнок с длинной шерстью, любит играть с мячиком.",
                UrlPhoto = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTfy09fP9Yv1Z8PXwlPwALtee_kn-dDjYcpr4MozfTi1W4XSxp6yCNOR1w&s=10"
            }
        };
    }

    public List<Cat> GetAll()
    {
        return cats;
    }

    public Cat GetById(int id)
    {
        var cat = cats.First(x => x.Id == id);

        return cat;
    }

    public bool IsFavorite(int id)
    {
        var isFavorite = favoriteCats.Any(x => x == id);

        return isFavorite;
    }

    public void Add(Cat cat)
    {
        var id = cats.Max(x => x.Id);

        cat.Id = ++id;

        cats.Add(cat);
    }

    public void AddFavorite(int id)
    {
        favoriteCats.Add(id);
    }

    public void RemoveFavorite(int id)
    {
        favoriteCats.Remove(id);
    }

    public void Remove(int id)
    {
        var cat = cats.First(x => x.Id == id);
        cats.Remove(cat);
    }

    public void Update(Cat cat)
    {
        var updatingCat = cats.First(x => x.Id == cat.Id);

        updatingCat.Name = cat.Name;
        updatingCat.Description = cat.Description;
        updatingCat.Age = cat.Age;
        updatingCat.UrlPhoto = cat.UrlPhoto;
        updatingCat.Color = cat.Color;
    }
}