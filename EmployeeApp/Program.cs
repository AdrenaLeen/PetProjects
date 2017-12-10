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
            // Переустановка и затем получение свойства Name.
            emp2.Name = "Марв";
            Console.WriteLine($"Сотрудник назван: {emp2.Name}");

            // Длиннее 15 символов! На консоль выводится сообщение об ошибке.
            Employee emp3 = new Employee();
            emp3.SetName("Зена королева воинов");

            Employee joe = new Employee();
            joe.Age++;

            Console.ReadLine();
        }
    }
}
