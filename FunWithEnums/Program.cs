using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunWithEnums
{
    // Специальное перечисление.
    // Начать нумерацию со значения 102.
    // Значения элементов в перечислении не обязательно должны быть последовательными!
    enum EmpType : byte
    {
        Manager = 10,
        Grunt = 1,
        Contractor = 100,
        VicePresident = 9
    }

    class Program
    {
        static void Main()
        {
        }
    }
}
