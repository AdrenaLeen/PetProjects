using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectOverrides
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("***** Тип System.Object *****");
            Person p1 = new Person();
            // Использовать унаследованные члены System.Object.
            Console.WriteLine($"ToString: {p1.ToString()}");
            Console.WriteLine($"Хэш: {p1.GetHashCode()}");
            Console.WriteLine($"Тип: {p1.GetType()}");
            // Создать другие ссылки на p1.
            Person p2 = p1;
            object o = p2;
            // Указывают ли ссылки на один и тот же объект в памяти?
            if (o.Equals(p1) && p2.Equals(o))
            {
                Console.WriteLine("Одинаковые сущности!");
            }

            Console.ReadLine();
        }
    }
}
