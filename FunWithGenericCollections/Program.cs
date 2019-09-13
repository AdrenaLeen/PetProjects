using System;
using System.Collections.Generic;

namespace FunWithGenericCollections
{
    class Program
    {
        static void Main()
        {
            UseGenericList();
            Console.WriteLine();

            UseGenericStack();
            Console.WriteLine();

            UseGenericQueue();
            Console.WriteLine();

            UseSortedSet();
            Console.WriteLine();

            UseDictionary();
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

        static void UseGenericStack()
        {
            Stack<Person> stackOfPeople = new Stack<Person>();
            stackOfPeople.Push(new Person { FirstName = "Гомер", LastName = "Симпсон", Age = 47 });
            stackOfPeople.Push(new Person { FirstName = "Мардж", LastName = "Симпсон", Age = 45 });
            stackOfPeople.Push(new Person { FirstName = "Лиза", LastName = "Симпсон", Age = 9 });

            // Просмотреть верхний элемент, вытолкнуть его и просмотреть снова.
            Console.WriteLine($"Первый объект Person: {stackOfPeople.Peek()}");
            Console.WriteLine($"Вытолкнут {stackOfPeople.Pop()}");

            Console.WriteLine($"Первый объект Person: {stackOfPeople.Peek()}");
            Console.WriteLine($"Вытолкнут {stackOfPeople.Pop()}");

            Console.WriteLine($"Первый объект Person: {stackOfPeople.Peek()}");
            Console.WriteLine($"Вытолкнут {stackOfPeople.Pop()}");

            try
            {
                Console.WriteLine($"Первый объект Person: {stackOfPeople.Peek()}");
                Console.WriteLine($"Вытолкнут {stackOfPeople.Pop()}");
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"Ошибка! {ex.Message}");
            }
        }

        static void GetCoffee(Person p) => Console.WriteLine($"{p.FirstName} получил кофе!");

        static void UseGenericQueue()
        {
            // Создать очередь из трёх человек.
            Queue<Person> peopleQ = new Queue<Person>();
            peopleQ.Enqueue(new Person { FirstName = "Гомер", LastName = "Симпсон", Age = 47 });
            peopleQ.Enqueue(new Person { FirstName = "Мардж", LastName = "Симпсон", Age = 45 });
            peopleQ.Enqueue(new Person { FirstName = "Лиза", LastName = "Симпсон", Age = 9 });

            // Заглянуть, кто первый в очереди.
            Console.WriteLine($"{peopleQ.Peek().FirstName} первый в очереди!");

            // Удалить всех из очереди.
            GetCoffee(peopleQ.Dequeue());
            GetCoffee(peopleQ.Dequeue());
            GetCoffee(peopleQ.Dequeue());

            // Попробовать извлечь кого-то из очереди снова.
            try
            {
                GetCoffee(peopleQ.Dequeue());
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine($"Ошибка! {e.Message}");
            }
        }

        private static void UseSortedSet()
        {
            // Создать несколько объектов Person с разными значениями возраста.
            SortedSet<Person> setOfPeople = new SortedSet<Person>(new SortPeopleByAge())
            {
                new Person {FirstName="Гомер", LastName="Симпсон", Age=47},
                new Person {FirstName="Мардж", LastName="Симпсон", Age=45},
                new Person {FirstName="Лиза", LastName="Симпсон", Age=9},
                new Person {FirstName="Барт", LastName="Симпсон", Age=8}
            };

            // Обратите внимание, что элементы отсортированы по возрасту!
            foreach (Person p in setOfPeople) Console.WriteLine(p);
            Console.WriteLine();

            // Добавить ещё несколько объектов Person с разными значениями возраста.
            setOfPeople.Add(new Person { FirstName = "Саку", LastName = "Джонс", Age = 1 });
            setOfPeople.Add(new Person { FirstName = "Мико", LastName = "Джонс", Age = 32 });

            foreach (Person p in setOfPeople) Console.WriteLine(p);
        }

        private static void UseDictionary()
        {
            // Наполнить с помощью метода Add().
            Dictionary<string, Person> peopleA = new Dictionary<string, Person>();
            peopleA.Add("Homer", new Person { FirstName = "Гомер", LastName = "Симпсон", Age = 47 });
            peopleA.Add("Marge", new Person { FirstName = "Мардж", LastName = "Симпсон", Age = 45 });
            peopleA.Add("Lisa", new Person { FirstName = "Лиза", LastName = "Симпсон", Age = 9 });

            // Получить элемент с ключом Homer.
            Person homer = peopleA["Homer"];
            Console.WriteLine(homer);

            // Наполнить с помощью синтаксиса инициализации.
            Dictionary<string, Person> peopleB = new Dictionary<string, Person>()
            {
                { "Homer", new Person { FirstName = "Гомер", LastName = "Симпсон", Age = 47 } },
                { "Marge", new Person { FirstName = "Мардж", LastName = "Симпсон", Age = 45 } },
                { "Lisa", new Person { FirstName = "Лиза", LastName = "Симпсон", Age = 9 } }
            };

            // Получить элемент с ключом Lisa.
            Person lisa = peopleB["Lisa"];
            Console.WriteLine(lisa);

            // Наполнить с помощью синтаксиса инициализации словаря.
            Dictionary<string, Person> peopleC = new Dictionary<string, Person>()
            {
                ["Homer"] = new Person { FirstName = "Гомер", LastName = "Симпсон", Age = 47 },
                ["Marge"] = new Person { FirstName = "Мардж", LastName = "Симпсон", Age = 45 },
                ["Lisa"] = new Person { FirstName = "Лиза", LastName = "Симпсон", Age = 9 }
            };

            // Получить элемент с ключом Marge.
            Person marge = peopleC["Marge"];
            Console.WriteLine(marge);
        }
    }
}
