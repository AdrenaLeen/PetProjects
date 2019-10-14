using System;
using System.Collections.Generic;

namespace SimpleIndexer
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("***** Индексаторы *****");
            PersonCollection myPeople = new PersonCollection();

            // Добавить объекты с применением синтаксиса индексатора.
            myPeople[0] = new Person("Гомер", "Симпсон", 40);
            myPeople[1] = new Person("Мардж", "Симпсон", 38);
            myPeople[2] = new Person("Лиза", "Симпсон", 9);
            myPeople[3] = new Person("Барт", "Симпсон", 7);
            myPeople[4] = new Person("Мэгги", "Симпсон", 2);

            // Получить и отобразить элементы с использованием индексатора.
            for (int i = 0; i < myPeople.Count; i++)
            {
                Console.WriteLine($"Номер лица: {i}");
                Console.WriteLine($"Имя и фамилия: {myPeople[i].FirstName} {myPeople[i].LastName}");
                Console.WriteLine($"Возраст: {myPeople[i].Age}");
                Console.WriteLine();
            }

            UseGenericListOfPeople();

            Console.ReadLine();
        }

        static void UseGenericListOfPeople()
        {
            List<Person> myPeople = new List<Person>();
            myPeople.Add(new Person("Лиза", "Симпсон", 9));
            myPeople.Add(new Person("Барт", "Симпсон", 7));

            // Изменить первый объект лица с помощью индексатора.
            myPeople[0] = new Person("Мэгги", "Симпсон", 2);

            // Now obtain and display each item using indexer.
            for (int i = 0; i < myPeople.Count; i++)
            {
                Console.WriteLine($"Номер лица: {i}");
                Console.WriteLine($"Имя и фамилия: {myPeople[i].FirstName} {myPeople[i].LastName}");
                Console.WriteLine($"Возраст: {myPeople[i].Age}");
                Console.WriteLine();
            }
        }
    }
}
