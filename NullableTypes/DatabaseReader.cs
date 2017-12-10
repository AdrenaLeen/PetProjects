using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullableTypes
{
    class DatabaseReader
    {
        // Поле данных типа, допускающего null.
        public int? numericValue = null;
        public bool? boolValue = true;

        // Обратите внимание на возвращаемый тип, допускающий null.
        public int? GetIntFromDatabase()
        {
            return numericValue;
        }

        // Обратите внимание на возвращаемый тип, допускающий null.
        public bool? GetBoolFromDatabase()
        {
            return boolValue;
        }
    }
}
