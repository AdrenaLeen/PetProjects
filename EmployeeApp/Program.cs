using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeApp
{
    class Program
    {
        static void Main()
        {
            Employee emp = new Employee();

            Console.WriteLine("***** Инкапсуляция *****");
            Employee emp2 = new Employee("Марвин", 456, 30000);
            emp2.GiveBonus(1000);
            emp2.DisplayStats();

            // Использовать методы get/set для взаимодействия с именем сотрудника, представленного объектом.
            emp2.SetName("Марв");
            Console.WriteLine($"Сотрудник назван: {emp2.GetName()}");

            Console.ReadLine();
        }
    }
}
