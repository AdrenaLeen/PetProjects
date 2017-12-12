using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees
{
    // Этот новый тип будет функционировать как включаемый класс.
    class BenefitPackage
    {
        // Предположим, что есть другие члены, представляющие медицинские/стоматологические программы и т.д.
        public double ComputePayDeduction()
        {
            return 125.0;
        }
    }
}
