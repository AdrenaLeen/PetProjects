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
    }
}
