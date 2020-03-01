using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Shop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Data
{
    public class DbObjects
    {
        public static void Initial(AppDbContent content)
        {
                        
            if(!content.BooksCategory.Any())
            {
                content.BooksCategory.AddRange(Categories.Select(c => c.Value));
            }
            if (!content.BooksWriter.Any())
            {
                content.BooksWriter.AddRange(CategoriesWriter.Select(c => c.Value));
            }

            if (!content.Book.Any())
            {
                content.AddRange(
                    new Book
                    {

                        name = "Дорогой Джон",
                        shortDesc = "История любви сквозь года",
                        longDesc = "Дорогой Джон… Так начинается письмо Саванны, которая, устав ждать любимого," +
                        "вышла замуж за другого. Эти слова разбили сердце Джона. Он больше не верит женщинам. " +
                        "Он больше не верит в любовь. Но разве настоящие чувства умирают? Разве ошибку молодости " +
                        "можно считать предательством? Пройдут годы, Джон и Саванна встретятся вновь. И искра былого пламени, " +
                        "оставшаяся в его душе, разгорится новым пожаром… Поздно? Но разве для счастья бывает поздно?",
                        img = "/img/1.jpg",
                        price = 18.00,
                        isFavourite = true,
                        available = true,                        
                        WriterName = "Николас Спаркс",
                        Writer = CategoriesWriter["Николас Спаркс"],
                        Category =Categories["Роман"]


                    },
                    new Book
                    {

                        name = "Спеши любить",
                        shortDesc = "Великолепная история о настоящей любви",
                        longDesc = "Тихий городок Бофор. Каждый год Лэндон Картер приезжает сюда, чтобы вспомнить историю своей первой любви..." +
                        "Историю страсти и нежности, много лет назад связавшей его, парня из богатой семьи, " +
                        "и Джейми Салливан, скромную дочь местного пастора. История радости и грусти, счастья и боли. " +
                        "Историю чувства, которое человеку доводится испытать лишь раз в жизни - и запомнить навсегда...",
                        img = "/img/2.jpg",
                        price = 13.50,
                        isFavourite = false,
                        available = true,                        
                        WriterName = "Николас Спаркс",
                        Writer = CategoriesWriter["Николас Спаркс"],
                        Category = Categories["Роман"]
                    },
                    new Book
                    {

                        name = "Сезон Гроз",
                        shortDesc = "Захватывающее продолжение рассказов о Ведьмаке",
                        longDesc = "Всегда, всегда будет существовать тьма. И всегда будет таящееся в темноте Зло, " +
                        "всегда будут во тьме клыки и когти, убийство и кровь. И всегда будут нужны ведьмаки. " +
                        "И крайне необходимо, чтобы они появлялись там, где в них нужда. Там, откуда доносятся крики о помощи. " +
                        "Там, откуда их зовут слабые. Чтобы они появились, призванные, с мечом в руке. " +
                        "С мечом, сверкание которого разобьет тьму, свет которого - разгонит мрак",
                        img = "/img/3.jpg",
                        price = 28.40,
                        isFavourite = false,
                        available = true,                        
                        WriterName = "Анджей Сапковский",
                        Writer = CategoriesWriter["Анджей Сапковский"],
                        Category = Categories["Фантастика"]
                    },
                    new Book
                    {

                        name = "Кровь эльфов",
                        shortDesc = "Захватывающее продолжение рассказов о Ведьмак",
                        longDesc = "Ведьмак — это мастер меча и мэтр волшебства, ведущий непрерывную войну с кровожадными монстрами, " +
                        "которые угрожают покою сказочной страны. Ведьмак — это мир на острие меча, ошеломляющее действие, " +
                        "незабываемые ситуации, великолепные боевые сцены.",
                        img = "/img/4.jpg",
                        price = 32.60,
                        isFavourite = true,
                        available = true,                        
                        WriterName = "Анджей Сапковский",
                        Writer = CategoriesWriter["Анджей Сапковский"],
                        Category = Categories["Фантастика"]
                    },
                    new Book
                    {

                        name = "Врата судьбы",
                        shortDesc = "Невероятные головоломки и интригующая развязка",
                        longDesc = "На старости лет Томми и Таппенс Бересфорды стали счастливыми обладателями старого дома в деревне. " +
                        "Вместе с имуществом они унаследовали некоторые безделушки, в том числе коллекцию старых книг." +
                        "И вот однажды, перебирая их, Таппенс неожиданно обратила внимание на подчеркнутые слова в романе Стивенсона " +
                        "Черная стрела, объединив которые, можно было прочесть фразу: Мэри Джордан умерла не своей смертью...",
                        img = "/img/5.jpg",
                        price = 23.30,
                        isFavourite = true,
                        available = true,                          
                        WriterName = "Агата Кристи",
                        Writer = CategoriesWriter["Агата Кристи"],
                        Category = Categories["Детектив"]
                    }
                );
            }
            content.SaveChanges();
        }

        private static Dictionary<string, BooksCategory> category;
        public static Dictionary<string, BooksCategory> Categories
        {
            get
            {
                if(category==null)
                {
                    var list = new BooksCategory[]
                    {
                    new BooksCategory {name="Фантастика", desc="Различные фантастические произведения"},
                    new BooksCategory {name="Роман", desc="Про любовь, дружбу, отношения"},
                    new BooksCategory {name="Детектив", desc="Загадочные преступления, невероятные расследования, головоломки"}
                    };
                    category = new Dictionary<string, BooksCategory>();
                    foreach(BooksCategory el in list)
                    {
                        category.Add(el.name, el);
                    }
                }

                return category;
            }
        }

        private static Dictionary<string, BooksWriter> writer;
        public static Dictionary<string, BooksWriter> CategoriesWriter
        {
            get
            {
                if (writer == null)
                {
                    var list = new BooksWriter[]
                    {
                    new BooksWriter {name="Анджей Сапковский"},
                    new BooksWriter {name="Сергей Лукьяненко"},
                    new BooksWriter {name="Агата Кристи"},
                    new BooksWriter {name="Николас Спаркс"}
                    };
                    writer = new Dictionary<string, BooksWriter>();
                    foreach (BooksWriter el in list)
                    {
                        writer.Add(el.name, el);
                    }
                }

                return writer;
            }
        }
    }
}
