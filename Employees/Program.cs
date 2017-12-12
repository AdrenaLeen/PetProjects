using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees
{
    class Program
    {
        // Создание объекта подкласса и доступ к функциональности базового класса.
        static void Main()
        {
            Console.WriteLine("***** Иерархия класса Employee *****");
            SalesPerson fred = new SalesPerson();
            fred.Age = 31;
            fred.Name = "Фрэд";
            fred.SalesNumber = 50;

            Console.ReadLine();
        }
    }
}
