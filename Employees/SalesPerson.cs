using System;

namespace Employees
{
    // Продавцам нужно знать количество продаж.
    // Класс SalesPerson запечатал метод GiveBonus()!
    class SalesPerson : Employee
    {
        public int SalesNumber { get; set; }

        public SalesPerson() { }

        // В качестве общего правила запомните, что все подклассы должны явно вызывать подходящий конструктор базового класса.
        // Это принадлежит нам!
        public SalesPerson(string fullName, int age, int empID, float currPay, string ssn, int numbOfSales) : base(fullName, age, empID, currPay, ssn) => SalesNumber = numbOfSales;

        // Бонус продавца зависит от количества продаж.
        public override sealed void GiveBonus(float amount)
        {
            int salesBonus;
            if (SalesNumber >= 0 && SalesNumber <= 100) salesBonus = 10;
            else
            {
                if (SalesNumber >= 101 && SalesNumber <= 200) salesBonus = 15;
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
