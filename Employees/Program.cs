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

            Manager chucky = new Manager("Чаки", 50, 92, 100000, "333-23-2322", 9000);
            double cost = chucky.GetBenefitCost();

            // Определить уровень льгот
            Employee.BenefitPackage.BenefitPackageLevel myBenefitLevel = Employee.BenefitPackage.BenefitPackageLevel.Platinum;

            // Выдать каждому сотруднику бонус?
            chucky.GiveBonus(300);
            chucky.DisplayStats();
            Console.WriteLine();

            SalesPerson fran = new SalesPerson("Фрэн", 43, 93, 3000, "932-32-3232", 31);
            fran.GiveBonus(200);
            fran.DisplayStats();
            Console.WriteLine();

            Console.ReadLine();
        }
    }
}
