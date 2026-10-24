using Lesson2.Models;

namespace Lesson2.Data;

public class Repository
{
    private readonly List<Cat> cats;

    public Repository()
    {
        cats = new List<Cat>
        {
            new Cat
            {
                Name = "Барсик",
                Age = 3,
                Color = "Рыжий",
                Description = "Ласковый и игривый кот, любит спать на подоконнике.",
                UrlPhoto = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTfy09fP9Yv1Z8PXwlPwALtee_kn-dDjYcpr4MozfTi1W4XSxp6yCNOR1w&s=10"
            },
            new Cat
            {
                Name = "Мурка",
                Age = 2,
                Color = "Белый",
                Description = "Пушистая кошка с голубыми глазами, очень спокойная.",
                UrlPhoto = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTfy09fP9Yv1Z8PXwlPwALtee_kn-dDjYcpr4MozfTi1W4XSxp6yCNOR1w&s=10"
            },
            new Cat
            {
                Name = "Васька",
                Age = 5,
                Color = "Серый",
                Description = "Опытный охотник, любит гулять на улице.",
                UrlPhoto = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTfy09fP9Yv1Z8PXwlPwALtee_kn-dDjYcpr4MozfTi1W4XSxp6yCNOR1w&s=10"
            },
            new Cat
            {
                Name = "Снежок",
                Age = 1,
                Color = "Белый",
                Description = "Маленький котёнок, очень активный и любопытный.",
                UrlPhoto = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTfy09fP9Yv1Z8PXwlPwALtee_kn-dDjYcpr4MozfTi1W4XSxp6yCNOR1w&s=10"
            },
            new Cat
            {
                Name = "Том",
                Age = 4,
                Color = "Чёрный",
                Description = "Независимый и умный кот, любит тишину.",
                UrlPhoto = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTfy09fP9Yv1Z8PXwlPwALtee_kn-dDjYcpr4MozfTi1W4XSxp6yCNOR1w&s=10"
            },
            new Cat
            {
                Name = "Луна",
                Age = 2,
                Color = "Трёхцветная",
                Description = "Грациозная кошка, обожает внимание и ласку.",
                UrlPhoto = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTfy09fP9Yv1Z8PXwlPwALtee_kn-dDjYcpr4MozfTi1W4XSxp6yCNOR1w&s=10"
            },
            new Cat
            {
                Name = "Леопольд",
                Age = 6,
                Color = "Полосатый",
                Description = "Добрый и мудрый кот, всегда сохраняет спокойствие.",
                UrlPhoto = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTfy09fP9Yv1Z8PXwlPwALtee_kn-dDjYcpr4MozfTi1W4XSxp6yCNOR1w&s=10"
            },
            new Cat
            {
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
}