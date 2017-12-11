using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicInheritance
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("***** Базовое наследование *****");
            // Создать объект Car и установить базовую скорость.
            Car myCar = new Car(80);

            // Установить текущую скорость и вывести её на консоль.
            myCar.Speed = 50;
            Console.WriteLine($"Моя машина едет со скоростью {myCar.Speed} км/ч");

            // Создать объект MiniVan.
            MiniVan myVan = new MiniVan();
            myVan.Speed = 10;
            Console.WriteLine($"Мой вэн едет со скоростью {myVan.Speed} км/ч");

            Console.ReadLine();
        }
    }
}
