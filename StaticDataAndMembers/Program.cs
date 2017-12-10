using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaticDataAndMembers
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("***** Статические данные *****");
            // Создать объект счёта.
            SavingsAccount s1 = new SavingsAccount(50);
            // Вывести текущую процентную ставку.
            Console.WriteLine($"Процентная ставка: {SavingsAccount.GetInterestRate()}");

            // Попытаться изменить процентную ставку через свойство.
            SavingsAccount.SetInterestRate(0.08);

            // Создать второй объект счёта.
            SavingsAccount s2 = new SavingsAccount(100);
            // Должно быть выведено 0.08... не так ли?
            Console.WriteLine($"Процентная ставка: {SavingsAccount.GetInterestRate()}");

            // Создать новый объект; это не 'сбросит' процентную ставку.
            SavingsAccount s3 = new SavingsAccount(10000.75);
            Console.WriteLine($"Процентная ставка: {SavingsAccount.GetInterestRate()}");

            Console.ReadLine();
        }
    }
}
