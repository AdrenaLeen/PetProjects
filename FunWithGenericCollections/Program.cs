using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunWithGenericCollections
{
    class Program
    {
        static void Main()
        {
            UseGenericList();
            Console.WriteLine();

            Console.ReadLine();
        }

        private static void UseGenericList()
        {
            // Создать список объектов Person и заполнить его с помощью синтаксиса инициализации объектов и коллекции.
            List<Person> people = new List<Person>()
            {
                new Person {FirstName="Гомер", LastName="Симпсон", Age=47},
                new Person {FirstName="Мардж", LastName="Симпсон", Age=45},
                new Person {FirstName="Лиза", LastName="Симпсон", Age=9},
                new Person {FirstName="Барт", LastName="Симпсон", Age=8}
            };

            // Вывести количество элементов в списке.
            Console.WriteLine($"Элементов в списке: {people.Count}");

            // Выполнить перечисление по списку.
            foreach (Person p in people) Console.WriteLine(p);

            // Вставить новый объект Person.
            Console.WriteLine("->Вставка нового объекта Person.");
            people.Insert(2, new Person { FirstName = "Мэгги", LastName = "Симпсон", Age = 2 });
            Console.WriteLine($"Элементов в списке: {people.Count}");

            // Скопировать данные в новый массив.
            Person[] arrayOfPeople = people.ToArray();
            for (int i = 0; i < arrayOfPeople.Length; i++) Console.WriteLine($"Имя: {arrayOfPeople[i].FirstName}");
        }
    }
}
