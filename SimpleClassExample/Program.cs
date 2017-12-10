using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleClassExample
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("***** Тип класса *****");

            // Разместить в памяти и сконфигурировать объект Car.
            Car myCar = new Car();
            myCar.petName = "Генри";
            myCar.currSpeed = 10;

            // Увеличить скорость автомобиля в несколько раз и вывести новое состояние.
            for (int i = 0; i <= 10; i++)
            {
                myCar.SpeedUp(5);
                myCar.PrintState();
            }

            Car myCar2 = new Car();
            myCar.petName = "Фред";

            Car myCar3;
            myCar3 = new Car();
            myCar3.petName = "Фред";

            Console.ReadLine();
        }
    }
}
