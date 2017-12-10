using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullableTypes
{
    class Program
    {
        static void Main()
        {
            // Всё в порядке! Строки являются ссылочными типами.
            string myString = null;
        }

        static void LocalNullableVariables()
        {
            // Определить несколько локальных переменных, допускающих null.
            int? nullableInt = 10;
            double? nullableDouble = 3.14;
            bool? nullableBool = null;
            char? nullableChar = 'a';
            int?[] arrayOfNullableInts = new int?[10];
        }

        static void LocalNullableVariablesUsingNullable()
        {
            // Определить несколько типов, допускающих null, с применением Nullable<T>.
            Nullable<int> nullableInt = 10;
            Nullable<double> nullableDouble = 3.14;
            Nullable<bool> nullableBool = null;
            Nullable<char> nullableChar = 'a';
            Nullable<int>[] arrayOfNullableInts = new Nullable<int>[10];
        }
    }
}
