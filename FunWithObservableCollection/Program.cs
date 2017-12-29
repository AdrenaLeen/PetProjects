using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace FunWithObservableCollection
{
    class Program
    {
        static void Main()
        {
            // Сделать коллекцию наблюдаемой и добавить в неё несколько объектов Person.
            ObservableCollection<Person> people = new ObservableCollection<Person>()
            {
                new Person{ FirstName = "Питэр", LastName = "Мёрфи", Age = 52 },
                new Person{ FirstName = "Кевин", LastName = "Кей", Age = 48 },
            };

            // Привязаться к событию CollectionChanged.
            people.CollectionChanged += people_CollectionChanged;
            people.Add(new Person("Фрэд", "Смит", 32));
            people.RemoveAt(0);

            Console.ReadLine();
        }

        static void people_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            // Выяснить действие, которое привело к генерации события.
            Console.WriteLine($"Событие для этого события: {e.Action}");

            // Было что-то удалено.
            if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Remove)
            {
                Console.WriteLine("Здесь старые элементы:");
                foreach (Person p in e.OldItems) Console.WriteLine(p);
                Console.WriteLine();
            }

            // Было что-то добавлено.
            if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add)
            {
                // Теперь вывести новые элементы, которые были вставлены.
                Console.WriteLine("Здесь новые элементы:");
                foreach (Person p in e.NewItems) Console.WriteLine(p);
            }
        }
    }
}
