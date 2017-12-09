using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImplicitlyTypedLocalVars
{
    class Program
    {
        static void Main()
        {
            DeclareImplicitVars();

            // Также допустимо!
            var myInt = 0;
            var anotherInt = myInt;
            string myString = "Вставай!";
            var myData = myString;

            Console.ReadLine();
        }

        static void DeclareImplicitVars()
        {
            // Неявно типизированные локальные переменные объявляются следующим образом:
            // var имяПеременной = начальноеЗначение;
            var myInt = 0;
            var myBool = true;
            var myString = "Time, marches on...";

            // Вывести имена лежащих в основе типов.
            Console.WriteLine("myInt является: {0}", myInt.GetType().Name);
            Console.WriteLine("myBool является: {0}", myBool.GetType().Name);
            Console.WriteLine("myString является: {0}", myString.GetType().Name);
        }

        static int GetAnInt()
        {
            var retVal = 9;
            return retVal;
        }

        static void ImplicitTypingIsStrongTyping()
        {
            // Компилятор знает, что s имеет тип System.String.
            var s = "Эта переменная может содержать только строковые данные!";
            s = "Это нормально...";

            // Можно обращаться к любому члену лежащего в основе типа.
            string upper = s.ToUpper();
        }
    }
}
