using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicDelegateProblem
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("***** Ах! Нет инкапсуляции! *****");
            
            // Создать объект Car.
            Car myCar = new Car();
            
            // Есть прямой доступ к делегату!
            myCar.listOfHandlers = new Car.CarEngineHandler(CallWhenExploded);
            myCar.Accelerate(10);

            // Теперь можно присвоить полностью новый объект... сбивает с толку в лучшем случае.
            myCar.listOfHandlers = new Car.CarEngineHandler(CallHereToo);
            myCar.Accelerate(10);

            // Вызывающий код может также напрямую вызывать делегат!
            myCar.listOfHandlers.Invoke("Хи, хи, хи...");

            Console.ReadLine();
        }

        static void CallWhenExploded(string msg)
        { Console.WriteLine(msg); }

        static void CallHereToo(string msg)
        { Console.WriteLine(msg); }
    }
}
