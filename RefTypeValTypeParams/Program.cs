using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefTypeValTypeParams
{
    class Program
    {
        static void Main()
        {
            // Передача ссылочных типов по значению
            Console.WriteLine("***** Передача объектов Person по значению *****");

            Person fred = new Person("Фред", 12);
            // Перед вызовом
            Console.WriteLine("До вызова по значению Person равно:");
            fred.Display();
            SendAPersonByValue(fred);
            // После вызова
            Console.WriteLine("После вызова по значению Person равно:");
            fred.Display();

            Console.ReadLine();
        }

        static void SendAPersonByValue(Person p)
        {
            // Изменить значение возраста в p?
            p.personAge = 99;

            // Увидит ли вызывающий код это изменение?
            p = new Person("Никки", 99);
        }
    }
}
