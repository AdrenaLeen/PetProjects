using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleGC
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("***** Основы сборки мусора *****");

            // Создать новый объект Car в управляемой куче. Возвращается ссылка на этот объект (refToMyCar).
            Car refToMyCar = new Car("Циппи", 100);

            Console.WriteLine(refToMyCar);

            MakeACar();

            Console.WriteLine("***** System.GC *****");

            // Вывести оценочное количество байтов, выделенных в куче.
            Console.WriteLine($"Оценочное количество байтов в куче: {GC.GetTotalMemory(false)}");

            // Значения MaxGeneration начинаются с нуля, поэтому при выводе добавить 1.
            Console.WriteLine($"У этой ОС {(GC.MaxGeneration + 1)} поколений объектов.");

            // Вывести поколение объекта refToMyCar.
            Console.WriteLine($"Поколение refToMyCar: {GC.GetGeneration(refToMyCar)}");

            Console.ReadLine();
        }

        static void MakeACar()
        {
            // Если myCar - единственная ссылка на объект Car, то после завершения этого метода объект Car *может* быть уничтожен.
            Car myCar = new Car();

            myCar = null;
        }
    }
}
