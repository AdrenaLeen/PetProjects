using FunWithObservableCollection;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

var people = new ObservableCollection<Person>()
{
    new Person{ FirstName = "Питэр", LastName = "Мерфи", Age = 52 },
    new Person{ FirstName = "Кевин", LastName = "Кей", Age = 48 },
};

// Привязаться к событию CollectionChanged.
people.CollectionChanged += People_CollectionChanged;
people.Add(new Person("Фрэд", "Смит", 32));
people.RemoveAt(0);

Console.ReadLine();

static void People_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
{
    // Выяснить действие, которое привело к генерации события.
    Console.WriteLine($"Событие для этого события: {e.Action}");

    // Было что-то удалено.
    if (e.Action == NotifyCollectionChangedAction.Remove)
    {
        Console.WriteLine("Здесь старые элементы:");
        if (e.OldItems != null)
        {
            foreach (Person p in e.OldItems) Console.WriteLine(p);
        }
        Console.WriteLine();
    }

    // Было что-то добавлено.
    if (e.Action == NotifyCollectionChangedAction.Add)
    {
        // Теперь вывести новые элементы, которые были вставлены.
        Console.WriteLine("Здесь новые элементы:");
        if (e.NewItems != null)
        {
            foreach (Person p in e.NewItems) Console.WriteLine(p);
        }
    }
}