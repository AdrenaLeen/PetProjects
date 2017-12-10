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
    // На этот раз для элементов EmpType используется тип byte.
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
            Console.WriteLine("**** Тип enum *****");

            // Создать переменную типа EmpType.
            EmpType emp = EmpType.Contractor;
            AskForBonus(emp);

            // Вывести тип хранилища для значений перечисления.
            Console.WriteLine($"EmpType использует {Enum.GetUnderlyingType(emp.GetType())} для хранения");

            // На этот раз для получения информации о типе используется операция typeof.
            Console.WriteLine($"EmpType использует {Enum.GetUnderlyingType(typeof(EmpType))} для хранения");

            Console.ReadLine();
        }

        // Перечисления как параметры
        static void AskForBonus(EmpType e)
        {
            switch (e)
            {
                case EmpType.Manager:
                    Console.WriteLine("Не желаете ли взамен фондовые опционы?");
                    break;
                case EmpType.Grunt:
                    Console.WriteLine("Вы, должно быть, шутите...");
                    break;
                case EmpType.Contractor:
                    Console.WriteLine("Вы уже получаете вполне достаточно...");
                    break;
                case EmpType.VicePresident:
                    Console.WriteLine("Очень хорошо, сэр!");
                    break;
            }
        }
    }
}
