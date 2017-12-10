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
            SavingsAccount s1 = new SavingsAccount(50);
            SavingsAccount s2 = new SavingsAccount(100);

            // Вывести текущую процентную ставку.
            Console.WriteLine($"Процентная ставка: {SavingsAccount.GetInterestRate()}");

            // Создать новый объект; это не 'сбросит' процентную ставку.
            SavingsAccount s3 = new SavingsAccount(10000.75);
            Console.WriteLine($"Процентная ставка: {SavingsAccount.GetInterestRate()}");

            Console.ReadLine();
        }
    }
}
