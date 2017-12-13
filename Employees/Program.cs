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

            // Привести объект frank к типу Hexagon невозможно, но этот код нормально скомпилируется!
            // Перехват возможной ошибки приведения.
            object frank = new Manager();
            Hexagon hex;
            try
            {
                hex = (Hexagon)frank;
            }
            catch (InvalidCastException ex)
            {
                Console.WriteLine(ex.Message);
            }

            // Использование ключевого слова as для проверки совместимости.
            object[] things = new object[4];
            things[0] = new Hexagon();
            things[1] = false;
            things[2] = new Manager();
            things[3] = "Последняя вещь";

            foreach (object item in things)
            {
                Hexagon h = item as Hexagon;
                if (h == null) Console.WriteLine("Этот элемент не является шестиугольником");
                else h.Draw();
            }

            Console.ReadLine();
        }

        static void GivePromotion(Employee emp)
        {
            // Повысить зарплату...
            // Предоставить место на парковке компании...
            Console.WriteLine($"{emp.Name} был продвинут по служебной лестнице!");
        }

        static void CastingExamples()
        {
            // Manager "является" System.Object, поэтому в переменной типа object можно сохранить ссылку на Manager.
            object frank = new Manager("Фрэнк Цаппа", 9, 3000, 40000, "111-11-1111", 5);
            GivePromotion((Manager)frank);

            // Manager также "является" Employee.
            Employee moonUnit = new Manager("МунЮнит Цаппа", 2, 3001, 20000, "101-11-1321", 1);
            GivePromotion(moonUnit);

            // PTSalesPerson "является" SalesPerson.
            SalesPerson jill = new PTSalesPerson("Jill", 834, 3002, 100000, "111-12-1119", 90);
            GivePromotion(jill);
        }
    }
}
