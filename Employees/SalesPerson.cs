using System;

namespace Employees
{
    // Продавцам нужно знать количество продаж.
    class SalesPerson : Employee
    {
        public int SalesNumber { get; set; }

        public SalesPerson() { }

        // В качестве общего правила запомните, что все подклассы должны явно вызывать подходящий конструктор базового класса.
        public SalesPerson(string fullName, int age, int empID, float currPay, string ssn, int numbOfSales)
            : base(fullName, age, empID, currPay, ssn, EmployeePayTypeEnum.Commission) => SalesNumber = numbOfSales;

        // Бонус продавца зависит от количества продаж.
        public override sealed void GiveBonus(float amount)
        {
            int salesBonus;
            if (0 <= SalesNumber && SalesNumber <= 100) salesBonus = 10;
            else
            {
                if (101 <= SalesNumber && SalesNumber <= 200) salesBonus = 15;
                else salesBonus = 20;
            }
            base.GiveBonus(amount * salesBonus);
        }

        public override void DisplayStats()
        {
            base.DisplayStats();
            Console.WriteLine($"Число продаж: {SalesNumber}");
        }
    }
}
