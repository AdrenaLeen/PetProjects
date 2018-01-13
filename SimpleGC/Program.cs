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
            Car refToMyCar = new Car("Циппи", 50);

            // Операция точки (.) используется для обращения к членам объекта с применением ссылочной переменной.
            Console.WriteLine(refToMyCar.ToString());

            MakeACar();

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
