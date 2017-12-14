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
            try
            {
                for (int i = 0; i < 10; i++) myCar.Accelerate(10);
            }
            catch (Exception e)
            {
                Console.WriteLine("*** Ошибка! ***");
                Console.WriteLine($"Имя члена: {e.TargetSite}");
                Console.WriteLine($"Класс, определяющий член: {e.TargetSite.DeclaringType}");
                Console.WriteLine($"Тип члена: {e.TargetSite.MemberType}");
                Console.WriteLine($"Сообщение: {e.Message}");
                Console.WriteLine($"Источник: {e.Source}");
                Console.WriteLine($"Стек: {e.StackTrace}");
            }
            // Ошибка была обработана, продолжается выполнение следующего оператора.
            Console.WriteLine("***** Вне логики исключения *****");

            Console.ReadLine();
        }
    }
}
