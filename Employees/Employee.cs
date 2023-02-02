using System;

namespace Employees
{
    abstract partial class Employee
    {
        public class BenefitPackage
        {
            public enum BenefitPackageLevel
            {
                Standard, Gold, Platinum
            }

            // Предположим, что есть другие члены, представляющие медицинские/стоматологические программы и т.д.
            public static double ComputePayDeduction() => 125.0;
        }

        public Employee() { }
        public Employee(string name, int id, float pay, string empSsn) : this(name, 0, id, pay, empSsn, EmployeePayTypeEnum.Salaried) { }
        public Employee(string name, int age, int id, float pay, string empSsn, EmployeePayTypeEnum payType)
        {
            Name = name;
            Age = age;
            Id = id;
            Pay = pay;
            SocialSecurityNumber = empSsn;
            PayType = payType;
        }

        public virtual void GiveBonus(float amount) => Pay += amount;

        // Открывает доступ к некоторому поведению, связанному со льготами.
        public static double GetBenefitCost() => BenefitPackage.ComputePayDeduction();

        public virtual void DisplayStats()
        {
            Console.WriteLine($"Имя сотрудника: {Name}");
            Console.WriteLine($"Идентификационный номер сотрудника: {Id}");
            Console.WriteLine($"Возраст: {Age}");
            Console.WriteLine($"Текущая выплата: {Pay}");
            Console.WriteLine($"SSN: {SocialSecurityNumber}");
        }
    }
}
