using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees
{
    // В класс Employee вложен класс BenefitPackage.
    // Превращение класса Employee в абстрактный тип для предотвращения прямого создания его экземпляров.
    abstract partial class Employee
    {
        // В класс BenefitPackage вложено перечисление BenefitPackageLevel.
        public class BenefitPackage
        {
            public enum BenefitPackageLevel
            {
                Standard, Gold, Platinum
            }

            // Предположим, что есть другие члены, представляющие медицинские/стоматологические программы и т.д.
            public double ComputePayDeduction()
            {
                return 125.0;
            }
        }

        // Методы.
        // Теперь этот метод может быть переопределён в производном классе.
        public virtual void GiveBonus(float amount)
        {
            Pay += amount;
        }

        // Обновлённый метод DisplayStats() теперь учитывает возраст.
        public virtual void DisplayStats()
        {
            // Имя сотрудника
            Console.WriteLine($"Имя: {Name}");
            // Идентификационный номер сотрудника
            Console.WriteLine($"ID: {ID}");
            // Возраст
            Console.WriteLine($"Возраст: {Age}");
            // Текущая выплата
            Console.WriteLine($"Выплата: {Pay}");
            Console.WriteLine($"SSN: {SocialSecurityNumber}");
        }

        // Метод доступа (метод get).
        public string GetName()
        {
            return empName;
        }

        // Метод изменения (метод set).
        public void SetName(string name)
        {
            // Перед присваиванием проверить входное значение.
            if (name.Length > 15) Console.WriteLine("Ошибка! Длина имени превышает 15 символов!");
            else empName = name;
        }

        // Открывает доступ к некоторому поведению, связанному со льготами.
        public double GetBenefitCost()
        {
            return empBenefits.ComputePayDeduction();
        }
    }
}
