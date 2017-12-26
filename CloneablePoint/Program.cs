using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloneablePoint
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("***** Клонирование объекта *****");
            
            // Две ссылки на один и тот же объект!
            Point p1 = new Point(50, 50);
            Point p2 = p1;
            p2.X = 0;
            Console.WriteLine(p1);
            Console.WriteLine(p2);

            // Обратите внимание, что Clone() возвращает простой тип object. Для получения производного типа требуется явное приведение.
            Console.WriteLine("Клонирование p3 и сохранение новой Point в p4");
            Point p3 = new Point(100, 100, "Джейн");
            Point p4 = (Point)p3.Clone();

            Console.WriteLine("До модификации:");
            Console.WriteLine($"p3: {p3}");
            Console.WriteLine($"p4: {p4}");
            p4.desc.PetName = "Моя новая точка";
            p4.X = 9;

            Console.WriteLine("Изменение p4.desc.petName и p4.X");
            Console.WriteLine("После модификации:");
            Console.WriteLine($"p3: {p3}");
            Console.WriteLine($"p4: {p4}");

            Console.ReadLine();
        }
    }
}
