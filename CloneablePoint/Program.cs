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
            Point p3 = new Point(100, 100);
            Point p4 = (Point)p3.Clone();

            // Изменить p4.X (что не приводит к изменению p3.X).
            p4.X = 0;

            // Вывести все объекты.
            Console.WriteLine(p3);
            Console.WriteLine(p4);

            Console.ReadLine();
        }
    }
}
