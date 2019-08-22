using System;

namespace Employees
{
    // Менеджерам нужно знать количество их фондовых опционов
    class Manager : Employee
    {
        public int StockOptions { get; set; }

        public Manager() { }

        // Это свойство определено в классе Manager.
        public Manager(string fullName, int age, int empID, float currPay, string ssn, int numbOfOpts) : base(fullName, age, empID, currPay, ssn) => StockOptions = numbOfOpts;

        public override void GiveBonus(float amount)
        {
            base.GiveBonus(amount);
            Random r = new Random();
            StockOptions += r.Next(500);
        }

        public override void DisplayStats()
        {
            base.DisplayStats();
            Console.WriteLine($"Число опционов: {StockOptions}");
        }
    }
}
