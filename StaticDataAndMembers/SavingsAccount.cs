﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaticDataAndMembers
{
    // Простой класс депозитного счёта
    class SavingsAccount
    {
        // Данные уровня экземпляра
        public double currBalance;
        // Статический элемент данных.
        public static double currInterestRate = 0.04;

        public SavingsAccount(double balance)
        {
            currBalance = balance;
        }
    }
}
