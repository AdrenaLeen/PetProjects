using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefaultAppDomainApp
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("***** Стандартный домен приложения *****");
            DisplayDADStats();
            Console.ReadLine();
        }

        private static void DisplayDADStats()
        {
            // Получить доступ к домену приложения для текущего потока.
            AppDomain defaultAD = AppDomain.CurrentDomain;

            // Вывести разнообразные статистические данные об этом домене.
            Console.WriteLine($"Дружественное имя этого домена: {defaultAD.FriendlyName}");
            Console.WriteLine($"Идентификатор домена в этом процессе: {defaultAD.Id}");
            Console.WriteLine($"Является ли стандартным доменом?: {defaultAD.IsDefaultAppDomain()}");
            Console.WriteLine($"Базовый каталог этого домена: {defaultAD.BaseDirectory}");
        }
    }
}
