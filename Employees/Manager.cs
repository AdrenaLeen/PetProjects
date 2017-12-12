using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees
{
    // Менеджерам нужно знать количество их фондовых опционов
    class Manager : Employee
    {
        public int StockOptions { get; set; }

        public Manager() { }

        public Manager(string fullName, int age, int empID, float currPay, string ssn, int numbOfOpts) : base(fullName, age, empID, currPay, ssn)
        {
            // Это свойство определено в классе Manager.
            StockOptions = numbOfOpts;
        }
    }
}
