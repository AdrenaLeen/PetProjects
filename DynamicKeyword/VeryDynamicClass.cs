using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicKeyword
{
    class VeryDynamicClass
    {
        // Динамическое поле.
        private static dynamic myDynamicField;

        // Динамическое свойство.
        public dynamic DynamicProperty { get; set; }

        // Динамический тип возврата и динамический тип параметра.
        public dynamic DynamicMethod(dynamic dynamicParam)
        {
            // Динамическая локальная переменная.
            dynamic dynamicLocalVar = "Локальная переменная";

            int myInt = 10;
            if (dynamicParam is int) return dynamicLocalVar;
            else return myInt;
        }
    }
}
