using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees
{
    // Продавцам нужно знать количество продаж.
    class SalesPerson : Employee
    {
        public int SalesNumber { get; set; }

        public SalesPerson() { }

        // В качестве общего правила запомните, что все подклассы должны явно вызывать подходящий конструктор базового класса.
        public SalesPerson(string fullName, int age, int empID, float currPay, string ssn, int numbOfSales) : base(fullName, age, empID, currPay, ssn)
        {
            // Это принадлежит нам!
            SalesNumber = numbOfSales;
        }
    }
}
