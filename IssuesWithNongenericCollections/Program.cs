using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace IssuesWithNongenericCollections
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        private static void SimpleBoxUnboxOperation()
        {
            // Создать переменную ValueType (типа int).
            int myInt = 25;

            // Упаковать int в ссылку на object.
            object boxedInt = myInt;

            // Распаковать в неподходящий тип данных, чтобы инициировать исключение времени выполнения.
            try
            {
                long unboxedInt = (long)boxedInt;
            }
            catch (InvalidCastException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void WorkWithArrayList()
        {
            // Типы значений автоматически упаковываются при передаче методу, который требует экземпляр object.
            ArrayList myInts = new ArrayList();
            myInts.Add(10);
            myInts.Add(20);
            myInts.Add(35);

            // Распаковка происходит, когда объект преобразуется обратно в данные, расположенные в стеке.
            int i = (int)myInts[0];

            // Теперь значение вновь упаковывается, т.к. метод WriteLine() требует типа object!
            Console.WriteLine($"Значение int: {i}");
        }
    }
}
