using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleException
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("***** Пример простого исключения *****");
            Console.WriteLine("=> Создание автомобиля!");
            Car myCar = new Car("Циппи", 20);
            myCar.CrankTunes(true);
            for (int i = 0; i < 10; i++) myCar.Accelerate(10);

            Console.ReadLine();
        }
    }
}
