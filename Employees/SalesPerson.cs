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
    }
}
