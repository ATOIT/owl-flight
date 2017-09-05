using System.Data.Entity;
using System.Linq;
using System.Threading;
using Domain.Concrete;
using Domain.Entityes;
using static System.DateTime;

namespace DressShopWebUI.Models
{
    /// <summary>
    /// Добавление "фейковых" записей в БД, для работы с ними
    /// </summary>
    public class DebugDb
    {

        public static void TestDb()
        {
            ShopContext db = new ShopContext();
            DbSet<Product> product = db.Product;
            if (!product.Any()) // проверка на наличие БД и записей.
                AddToDb();// Если БД пустая - заполнит "тестовыми значениями"
        }
        public static void AddToDb()
        {
            var db = new ShopContext();

            #region Товар

            db.Product.Add(new Product
            {
                Photo = "appleblack.png",
                Name = "НЕ З'ЇМ, ТАК ПОНАДКУШУЮ",
                Price = 158,
                Composition = "100% бавовна",
                Density = "140-150 г/м2.",
                Producer = "Україна.",
                Description = "футболка унісекс 100% бавовна",
                Style = "класичний.",
                S = true,
                M = true,
                L = true,
                Xl = true,
                Xxl = true,
                Xl3 = true,
                Xl4 = true,
                SelectedSize = "select",
                DateCreate = Now
            });
            Thread.Sleep(10);

            db.Product.Add(new Product
            {
                Photo = "owlwhite.png",
                Name = "OWL FLIGHT",
                Price = 158,
                Composition = "100% бавовна",
                Density = "140-150 г/м2.",
                Producer = "Україна.",
                Description = "футболка унісекс 100% бавовна",
                Style = "класичний.",
                S = true,
                M = true,
                L = true,
                Xl = true,
                Xxl = true,
                Xl3 = true,
                Xl4 = true,
                SelectedSize = "select",
                DateCreate = Now
            });
            Thread.Sleep(10);

            db.Product.Add(new Product
            {
                Photo = "globered.png",
                Name = "ГЛОБУС УКРАЇНИ",
                Price = 158,
                Composition = "100% бавовна",
                Density = "140-150 г/м2.",
                Producer = "Україна.",
                Description = "футболка унісекс 100% бавовна",
                Style = "класичний.",
                S = true,
                M = true,
                L = true,
                Xl = true,
                Xxl = true,
                Xl3 = true,
                Xl4 = true,
                SelectedSize = "select",
                DateCreate = Now
            });
            Thread.Sleep(10);

            db.Product.Add(new Product
            {
                Photo = "indianblue.png",
                Name = "ВОЖДЬ ІРОКЕЗІВ",
                Price = 158,
                Composition = "100% бавовна",
                Density = "140-150 г/м2.",
                Producer = "Україна.",
                Description = "футболка унісекс 100% бавовна",
                Style = "класичний.",
                S = true,
                M = true,
                L = true,
                Xl = true,
                Xxl = true,
                Xl3 = true,
                Xl4 = true,
                SelectedSize = "select",
                DateCreate = Now
            });
            Thread.Sleep(10);

            db.Product.Add(new Product
            {
                Photo = "owlblue.png",
                Name = "OWL FLIGHT",
                Price = 158,
                Composition = "100% бавовна",
                Density = "140-150 г/м2.",
                Producer = "Україна.",
                Description = "футболка унісекс 100% бавовна",
                Style = "класичний.",
                S = true,
                M = true,
                L = true,
                Xl = true,
                Xxl = true,
                Xl3 = true,
                Xl4 = true,
                SelectedSize = "select",
                DateCreate = Now
            });
            Thread.Sleep(10);

            db.Product.Add(new Product
            {
                Photo = "indianblack.png",
                Name = "ВОЖДЬ ІРОКЕЗІВ",
                Price = 158,
                Composition = "100% бавовна",
                Density = "140-150 г/м2.",
                Producer = "Україна.",
                Description = "футболка унісекс 100% бавовна",
                Style = "класичний.",
                S = true,
                M = true,
                L = true,
                Xl = true,
                Xxl = true,
                Xl3 = true,
                Xl4 = true,
                SelectedSize = "select",
                DateCreate = Now
            });
            Thread.Sleep(10);

            db.Product.Add(new Product
            {
                Photo = "applewhite.png",
                Name = "НЕ З'ЇМ, ТАК ПОНАДКУШУЮ",
                Price = 158,
                Composition = "100% бавовна",
                Density = "140-150 г/м2.",
                Producer = "Україна.",
                Description = "футболка унісекс 100% бавовна",
                Style = "класичний.",
                S = true,
                M = true,
                L = true,
                Xl = true,
                Xxl = true,
                Xl3 = true,
                Xl4 = true,
                SelectedSize = "select",
                DateCreate = Now
            });
            Thread.Sleep(10);

            db.Product.Add(new Product
            {
                Photo = "owlred.png",
                Name = "OWL FLIGHT",
                Price = 158,
                Composition = "100% бавовна",
                Density = "140-150 г/м2.",
                Producer = "Україна.",
                Description = "футболка унісекс 100% бавовна",
                Style = "класичний.",
                S = true,
                M = true,
                L = true,
                Xl = true,
                Xxl = true,
                Xl3 = true,
                Xl4 = true,
                SelectedSize = "select",
                DateCreate = Now
            });
            Thread.Sleep(10);

            db.Product.Add(new Product
            {
                Photo = "globeblack.png",
                Name = "ГЛОБУС УКРАЇНИ",
                Price = 158,
                Composition = "100% бавовна",
                Density = "140-150 г/м2.",
                Producer = "Україна.",
                Description = "футболка унісекс 100% бавовна",
                Style = "класичний.",
                S = true,
                M = true,
                L = true,
                Xl = true,
                Xxl = true,
                Xl3 = true,
                Xl4 = true,
                SelectedSize = "select",
                DateCreate = Now
            });
            Thread.Sleep(10);

            db.Product.Add(new Product
            {
                Photo = "applered.png",
                Name = "НЕ З'ЇМ, ТАК ПОНАДКУШУЮ",
                Price = 158,
                Composition = "100% бавовна",
                Density = "140-150 г/м2.",
                Producer = "Україна.",
                Description = "футболка унісекс 100% бавовна",
                Style = "класичний.",
                S = true,
                M = true,
                L = true,
                Xl = true,
                Xxl = true,
                Xl3 = true,
                Xl4 = true,
                SelectedSize = "select",
                DateCreate = Now
            });
            Thread.Sleep(10);

            db.Product.Add(new Product
            {
                Photo = "indianwhite.png",
                Name = "ВОЖДЬ ІРОКЕЗІВ",
                Price = 158,
                Composition = "100% бавовна",
                Density = "140-150 г/м2.",
                Producer = "Україна.",
                Description = "футболка унісекс 100% бавовна",
                Style = "класичний.",
                S = true,
                M = true,
                L = true,
                Xl = true,
                Xxl = true,
                Xl3 = true,
                Xl4 = true,
                SelectedSize = "select",
                DateCreate = Now
            });
            Thread.Sleep(10);

            db.Product.Add(new Product
            {
                Photo = "appleblue.png",
                Name = "НЕ З'ЇМ, ТАК ПОНАДКУШУЮ",
                Price = 158,
                Composition = "100% бавовна",
                Density = "140-150 г/м2.",
                Producer = "Україна.",
                Description = "футболка унісекс 100% бавовна",
                Style = "класичний.",
                S = true,
                M = true,
                L = true,
                Xl = true,
                Xxl = true,
                Xl3 = true,
                Xl4 = true,
                SelectedSize = "select",
                DateCreate = Now
            });
            Thread.Sleep(10);

            db.Product.Add(new Product
            {
                Photo = "indianred.png",
                Name = "ВОЖДЬ ІРОКЕЗІВ",
                Price = 158,
                Composition = "100% бавовна",
                Density = "140-150 г/м2.",
                Producer = "Україна.",
                Description = "футболка унісекс 100% бавовна",
                Style = "класичний.",
                S = true,
                M = true,
                L = true,
                Xl = true,
                Xxl = true,
                Xl3 = true,
                Xl4 = true,
                SelectedSize = "select",
                DateCreate = Now
            });
            Thread.Sleep(10);

            db.Product.Add(new Product
            {
                Photo = "globewhite.png",
                Name = "ГЛОБУС УКРАЇНИ",
                Price = 158,
                Composition = "100% бавовна",
                Density = "140-150 г/м2.",
                Producer = "Україна.",
                Description = "футболка унісекс 100% бавовна",
                Style = "класичний.",
                S = true,
                M = true,
                L = true,
                Xl = true,
                Xxl = true,
                Xl3 = true,
                Xl4 = true,
                SelectedSize = "select",
                DateCreate = Now
            });
            Thread.Sleep(10);

            db.Product.Add(new Product
            {
                Photo = "owlblack.png",
                Name = "OWL FLIGHT",
                Price = 158,
                Composition = "100% бавовна",
                Density = "140-150 г/м2.",
                Producer = "Україна.",
                Description = "футболка унісекс 100% бавовна",
                Style = "класичний.",
                S = true,
                M = true,
                L = true,
                Xl = true,
                Xxl = true,
                Xl3 = true,
                Xl4 = true,
                SelectedSize = "select",
                DateCreate = Now
            });
            Thread.Sleep(10);

            db.Product.Add(new Product
            {
                Photo = "indianblue.png",
                Name = "ВОЖДЬ ІРОКЕЗІВ",
                Price = 158,
                Composition = "100% бавовна",
                Density = "140-150 г/м2.",
                Producer = "Україна.",
                Description = "футболка унісекс 100% бавовна",
                Style = "класичний.",
                S = true,
                M = true,
                L = true,
                Xl = true,
                Xxl = true,
                Xl3 = true,
                Xl4 = true,
                SelectedSize = "select",
                DateCreate = Now
            });
            Thread.Sleep(10);
            #endregion

            #region Слайдер

            db.Slider.Add(new Slider
            {
                SlidePhoto = "indianblack.png",
                Name = "ВОЖДЬ ІРОКЕЗІВ",
                Number = 0,
                SlideDescription = "Щільність: 140-150 г/м2. Розміри:  S, M,L, XL,XXL,3XL,4XL  Країна - виробник: Україна. Опис: футболка унісекс 100 % бавовна  Стиль: класичний."
            });
            Thread.Sleep(10);

            db.Slider.Add(new Slider
            {
                SlidePhoto = "three.png",
                Name = "АКЦІЯ!!!",
                Number = 1,
                SlideDescription = "Придбайте 3 футболки ТМ \"OWL FLIGHT\" та отримуйте купон-знижка 10 євро на послуги з працевлаштування у Польші та Чехії від наших партнерів"
            });
            Thread.Sleep(10);

            db.Slider.Add(new Slider
            {
                SlidePhoto = "photo1.jpg",
                Name = "Фестиваль \"Україна та Ізраїль разом\"",
                Number = 2,
                SlideDescription = "Фестиваль \"Україна і Ізраїль разом\", на фото посол України"
            });
            Thread.Sleep(10);

            db.Slider.Add(new Slider
            {
                SlidePhoto = "globewhite.png",
                Name = "ГЛОБУС УКРАЇНИ",
                Number = 3,
                SlideDescription = "Щільність: 140-150 г/м2. Розміри:  S, M,L, XL,XXL,3XL,4XL Країна - виробник: Україна. Опис:футболка унісекс 100 % бавовна  Стиль: класичний."
            });
            Thread.Sleep(10);

            db.Slider.Add(new Slider
            {
                SlidePhoto = "three.png",
                Name = "АКЦІЯ!!!",
                Number = 4,
                SlideDescription = "Придбайте 3 футболки ТМ \"OWL FLIGHT\" та отримуйте купон-знижка 10 євро  на послуги з працевлаштування у Польші та Чехії  від наших партнерів"
            });
            Thread.Sleep(10);

            db.Slider.Add(new Slider
            {
                SlidePhoto = "applered.png",
                Name = "Долучайся! Купуй! Допомагай!",
                Number = 5,
                SlideDescription = "Товар, який ви тримаєте в руках, створений зусиллями учасників та волонтерів АТО. Тільки при вашій підтримці ми зможемо більше!"
            });
            Thread.Sleep(10);

            #endregion

            #region Заказы

            db.OrderDetails.Add(new OrderDetails
            {
                Status = "Новие замовлення",
                Address = "На деревню бабушке",
                ClientName = "Вася Пупкин",
                Delivery = "Нова пошта",
                Email = "pupkin@gmail.com",
                Payment = "На карточку",
                Phone = "099 99 99 999",
                Сomment = "Хочуууу такую футболкууу!!!",
                Order = "indianblue.png , ВОЖДЬ ИРОКЕЗОВ, XXL"
            });
            Thread.Sleep(10);

            db.OrderDetails.Add(new OrderDetails
            {
                Status = "Виконане замовлення",
                Address = "На деревню бабушке",
                ClientName = "Петручо",
                Delivery = "Нова пошта",
                Email = "pupkin@gmail.com",
                Payment = "На карточку",
                Phone = "099 99 99 999",
                Сomment = "Хочуууу такую футболкууу!!!",
                Order = "indianblue.png , ВОЖДЬ ИРОКЕЗОВ, XXL"
            });
            Thread.Sleep(10);

            db.OrderDetails.Add(new OrderDetails
            {
                Status = "Новие замовлення",
                Address = "На деревню бабушке",
                ClientName = "Алибаба",
                Delivery = "Нова пошта",
                Email = "pupkin@gmail.com",
                Payment = "На карточку",
                Phone = "099 99 99 999",
                Сomment = "Хочуууу такую футболкууу!!!",
                Order = "indianblue.png , ВОЖДЬ ИРОКЕЗОВ, XXL"
            });
            Thread.Sleep(10);

            #endregion

            db.SaveChanges();
        }

    }
}