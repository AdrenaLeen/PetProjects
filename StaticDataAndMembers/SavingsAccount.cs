using System;

namespace StaticDataAndMembers
{
    // Простой класс депозитного счёта
    class SavingsAccount
    {
        // Данные уровня экземпляра
        public double currBalance;
        // Статический элемент данных.
        public static double currInterestRate;

        // Статический конструктор!
        static SavingsAccount()
        {
            Console.WriteLine("В статическом конструкторе!");
            currInterestRate = 0.04;
        }

        // Обратите внимание, что наш конструктор устанавливает значение статического поля currInterestRate.
        public SavingsAccount(double balance) => currBalance = balance;

        // Статические члены для установки/получения процентной ставки.
        public static void SetInterestRate(double newRate) => currInterestRate = newRate;

        public static double GetInterestRate() => currInterestRate;
    }
}
