using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComparableCar
{
    class Program
    {
        // Использование интерфейса IComparable.
        static void Main()
        {
            Console.WriteLine("***** Сортировка объектов *****");

            // Создать массив объектов Car.
            Car[] myAutos = new Car[5];
            myAutos[0] = new Car("Расти", 80, 1);
            myAutos[1] = new Car("Мэри", 40, 234);
            myAutos[2] = new Car("Вайпер", 40, 34);
            myAutos[3] = new Car("Мэл", 40, 4);
            myAutos[4] = new Car("Чаки", 40, 5);

            // Отобразить текущее содержимое массива.
            Console.WriteLine("Здесь неупорядоченное множество машин:");
            foreach (Car c in myAutos) Console.WriteLine($"{c.CarID} {c.PetName}");

            // Сортируются ли объекты Car? Пока ещё нет!
            // Теперь отсортировать массив, используя IComparable!
            Array.Sort(myAutos);
            Console.WriteLine();

            // Отобразить отсортированное содержимое массива.
            Console.WriteLine("Здесь упорядоченное множество машин:");
            foreach (Car c in myAutos) Console.WriteLine($"{c.CarID} {c.PetName}");

            // Теперь сортировать по дружественному имени.
            Array.Sort(myAutos, new PetNameComparer());
            Console.WriteLine();

            // Вывести отсортированный массив.
            Console.WriteLine("Упорядочение по дружественному имени:");
            foreach (Car c in myAutos) Console.WriteLine($"{c.CarID} {c.PetName}");

            Console.ReadLine();
        }
    }
}
