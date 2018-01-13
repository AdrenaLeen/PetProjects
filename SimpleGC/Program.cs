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

            // Создать большое количество объектов в целях тестирования.
            object[] tonsOfObjects = new object[50000];
            for (int i = 0; i < 50000; i++) tonsOfObjects[i] = new object();

            // Принудительно запустить сборку мусора и ожидать финализации каждого объекта.
            // Исследовать только объекты поколения 0.
            GC.Collect(0, GCCollectionMode.Forced);
            GC.WaitForPendingFinalizers();

            // Вывести поколение refToMyCar.
            Console.WriteLine($"Поколение refToMyCar: {GC.GetGeneration(refToMyCar)}");

            // Посмотреть, существует ли ещё tonsOfObjects[9000].
            if (tonsOfObjects[9000] != null) Console.WriteLine($"Поколение tonsOfObjects[9000]: {GC.GetGeneration(tonsOfObjects[9000])}");
            else Console.WriteLine("tonsOfObjects[9000] больше нет в живых.");

            // Вывести количество проведённых сборок мусора для разных поколений.
            Console.WriteLine($"Поколение 0 было собрано {GC.CollectionCount(0)} раз");
            Console.WriteLine($"Поколение 1 было собрано {GC.CollectionCount(1)} раз");
            Console.WriteLine($"Поколение 2 было собрано {GC.CollectionCount(2)} раз");

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
