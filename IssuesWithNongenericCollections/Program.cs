using System.Collections;
using IssuesWithNongenericCollections;

SimpleBoxUnboxOperation();
WorkWithArrayList();
ArrayListOfRandomObjects();
UsePersonCollection();
UseGenericList();
Console.ReadLine();

static void SimpleBoxUnboxOperation()
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
    var myInts = new ArrayList { 10, 20, 35 };

    // Распаковка происходит, когда объект преобразуется обратно в данные, расположенные в стеке.
    int i = (int)myInts[0];

    // Теперь значение вновь упаковывается, т.к. метод WriteLine() требует типа object!
    Console.WriteLine($"Значение int: {i}");
}

static void ArrayListOfRandomObjects()
{
    // ArrayList может хранить вообще всё что угодно.
    var _ = new ArrayList
    {
        true,
        new OperatingSystem(PlatformID.MacOSX, new Version(10, 0)),
        66,
        3.14
    };
}

static void UsePersonCollection()
{
    Console.WriteLine("***** Коллекция людей *****");
    var myPeople = new PersonCollection();
    myPeople.AddPerson(new Person("Гомер", "Симпсон", 40));
    myPeople.AddPerson(new Person("Мардж", "Симпсон", 38));
    myPeople.AddPerson(new Person("Лиза", "Симпсон", 9));
    myPeople.AddPerson(new Person("Барт", "Симпсон", 7));
    myPeople.AddPerson(new Person("Мэгги", "Симпсон", 2));

    foreach (Person p in myPeople) Console.WriteLine(p);
}

static void UseGenericList()
{
    Console.WriteLine("***** Обобщенные коллекции *****");

    // Этот объект List<> может хранить только объекты Person.
    var morePeople = new List<Person> { new Person("Фрэнк", "Блэк", 50) };
    Console.WriteLine(morePeople[0]);

    // Этот объект List<> может хранить только целые числа.
    var moreInts = new List<int> { 10, 2 };
    int _ = moreInts[0] + moreInts[1];
}