using System;

namespace StringIndexer
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("***** Индексаторы *****");

            PersonCollection myPeople = new PersonCollection();
            myPeople["Homer"] = new Person("Гомер", "Симпсон", 40);
            myPeople["Marge"] = new Person("Мардж", "Симпсон", 38);

            // Получить объект лица "Homer" и вывести данные.
            Person homer = myPeople["Homer"];
            Console.WriteLine(homer);

            Console.ReadLine();
        }
    }
}
