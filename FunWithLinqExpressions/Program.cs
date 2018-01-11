using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunWithLinqExpressions
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("***** Операции запросов *****");

            // Этот массив будет основой для тестирования...
            ProductInfo[] itemsInStock = new[]
            {
                new ProductInfo{ Name = "Mac's Coffee", Description = "Coffee with TEETH", NumberInStock = 24},
                new ProductInfo{ Name = "Milk Maid Milk", Description = "Milk cow's love", NumberInStock = 100},
                new ProductInfo{ Name = "Pure Silk Tofu", Description = "Bland as Possible", NumberInStock = 120},
                new ProductInfo{ Name = "Cruchy Pops", Description = "Cheezy, peppery goodness", NumberInStock = 2},
                new ProductInfo{ Name = "RipOff Water", Description = "From the tap to your wallet", NumberInStock = 100},
                new ProductInfo{ Name = "Classic Valpo Pizza", Description = "Everyone loves pizza!", NumberInStock = 73}
            };

            SelectEverything(itemsInStock);
            ListProductNames(itemsInStock);
            GetOverstock(itemsInStock);
            GetNamesAndDescriptions(itemsInStock);
            GetCountFromQuery();
            ReverseEverything(itemsInStock);
            AlphabetizeProductNames(itemsInStock);

            // Здесь мы будем вызывать разнообразные методы!
            Console.ReadLine();
        }

        static void SelectEverything(ProductInfo[] products)
        {
            // Получить всё!
            Console.WriteLine("Все детали продукта:");
            IEnumerable<ProductInfo> allProducts = from p in products select p;
            foreach (ProductInfo prod in allProducts) Console.WriteLine(prod);
            Console.WriteLine();
        }

        static void ListProductNames(ProductInfo[] products)
        {
            // Теперь получить только наименования товаров.
            Console.WriteLine("Только наименования продуктов:");
            IEnumerable<string> names = from p in products select p.Name;
            foreach (string n in names) Console.WriteLine($"Наименование: {n}");
            Console.WriteLine();
        }

        static void GetOverstock(ProductInfo[] products)
        {
            Console.WriteLine("Излишки продуктов!");

            // Получить только товары со складским запасом более 25 единиц.
            IEnumerable<ProductInfo> overstock = from p in products where p.NumberInStock > 25 select p;

            foreach (ProductInfo c in overstock) Console.WriteLine(c);
            Console.WriteLine();
        }

        static void GetNamesAndDescriptions(ProductInfo[] products)
        {
            Console.WriteLine("Имя и описание:");
            var nameDesc = from p in products select new { p.Name, p.Description };

            // Можно было бы также использовать свойства Name и Description напрямую.
            foreach (var item in nameDesc) Console.WriteLine(item);

            Console.WriteLine();
        }

        static void GetCountFromQuery()
        {
            string[] currentVideoGames = {"Morrowind", "Uncharted 2", "Fallout 3", "Daxter", "System Shock 2"};

            // Получить количество элементов из запроса.
            int numb = (from g in currentVideoGames where g.Length > 6 select g).Count();

            // Вывести количество элементов.
            Console.WriteLine($"{numb} элемента подпадают под запрос LINQ.");

            Console.WriteLine();
        }

        static void ReverseEverything(ProductInfo[] products)
        {
            Console.WriteLine("Продукты в обратном порядке:");
            IEnumerable<ProductInfo> allProducts = from p in products select p;
            foreach (ProductInfo prod in allProducts.Reverse()) Console.WriteLine(prod);
            Console.WriteLine();
        }

        static void AlphabetizeProductNames(ProductInfo[] products)
        {
            // Получить наименования товаров в алфавитном порядке.
            IEnumerable<ProductInfo> subset = from p in products orderby p.Name select p;

            Console.WriteLine("Отсортировано по имени:");
            foreach (ProductInfo p in subset) Console.WriteLine(p);
            Console.WriteLine();
        }
    }
}
