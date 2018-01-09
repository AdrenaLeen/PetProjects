using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnonimousTypes
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("***** Анонимные типы *****");

            // Создать анонимный тип, представляющий автомобиль.
            var myCar = new { Color = "Ярко-розовый", Make = "Saab", CurrentSpeed = 55 };

            // Выполнить рефлексию того, что сгенерировал компилятор.
            ReflectOverAnonymousType(myCar);

            // Вывести на консоль цвет и производителя.
            Console.WriteLine($"Моя машина - {myCar.Color} {myCar.Make}.");

            // А теперь вызвать вспомогательный метод для построения анонимного типа с указанием аргументов
            BuildAnonType("BMW", "Чёрный", 90);

            EqualityTest();

            // Создать анонимный тип, который состоит из ещё одного анонимного типа.
            var purchaseItem = new
            {
                TimeBought = DateTime.Now,
                ItemBought = new { Color = "Красный", Make = "Saab", CurrentSpeed = 55 },
                Price = 34.000
            };
            ReflectOverAnonymousType(purchaseItem);

            Console.ReadLine();
        }

        static void BuildAnonType(string make, string color, int currSp)
        {
            // Построить анонимный тип с применением входных аргументов.
            var car = new { Make = make, Color = color, Speed = currSp };

            // Обратите внимание, что теперь этот тип можно использовать для получения данных свойств!
            Console.WriteLine($"У вас есть {car.Color} {car.Make}, который едет со скоростью {car.Speed} км/ч");

            // Анонимные типы имеют специальные реализации каждого виртуального метода System.Object. Например:
            Console.WriteLine($"ToString() == {car.ToString()}");
            Console.WriteLine();
        }

        static void ReflectOverAnonymousType(object obj)
        {
            Console.WriteLine($"obj - элемент типа: {obj.GetType().Name}");
            Console.WriteLine($"Базовый класс {obj.GetType().Name} - это {obj.GetType().BaseType}");
            Console.WriteLine($"obj.ToString() == {obj.ToString()}");
            Console.WriteLine($"obj.GetHashCode() == {obj.GetHashCode()}");
            Console.WriteLine();
        }

        static void EqualityTest()
        {
            // Создать два анонимных класс с идентичными наборами пар "имя-значение".
            var firstCar = new { Color = "Ярко-розовый", Make = "Saab", CurrentSpeed = 55 };
            var secondCar = new { Color = "Ярко-розовый", Make = "Saab", CurrentSpeed = 55 };

            // Считаются ли они эквивалентными, когда используется Equals()?
            if (firstCar.Equals(secondCar)) Console.WriteLine("Одинаковые анонимные объекты!");
            else Console.WriteLine("Разные анонимные объекты!");

            // Можно ли проверить их эквивалетность с помощью операции ==?
            if (firstCar == secondCar) Console.WriteLine("Одинаковые анонимные объекты!");
            else Console.WriteLine("Разные анонимные объекты!");

            // Имеют ли эти объекты в основе один и тот же тип?
            if (firstCar.GetType().Name == secondCar.GetType().Name) Console.WriteLine("Мы оба одного типа!");
            else Console.WriteLine("У нас разные типы!");

            // Отобразить все детали.
            Console.WriteLine();
            ReflectOverAnonymousType(firstCar);
            ReflectOverAnonymousType(secondCar);
        }
    }
}
