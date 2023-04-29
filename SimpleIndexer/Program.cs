using SimpleIndexer;
using System.Data;

Console.WriteLine("***** Индексаторы *****");
var myPeople = new PersonCollection();

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

var myPeopleStrings = new PersonCollectionStringIndexer();

myPeopleStrings["Гомер"] = new Person("Гомер", "Симпсон", 40);
myPeopleStrings["Мардж"] = new Person("Мардж", "Симпсон", 38);

// Получить объект лица Гомер и вывести данные.
Person homer = myPeopleStrings["Гомер"];
Console.WriteLine(homer.ToString());

UseGenericListOfPeople();
MultiIndexerWithDataTable();

Console.ReadLine();

static void UseGenericListOfPeople()
{
    var myPeople = new List<Person>();
    myPeople.Add(new Person("Лиза", "Симпсон", 9));
    myPeople.Add(new Person("Барт", "Симпсон", 7));

    // Изменить первый объект лица с помощью индексатора.
    myPeople[0] = new Person("Мэгги", "Симпсон", 2);

    // Получить и отобразить каждый элемент, используя индексатор.
    for (int i = 0; i < myPeople.Count; i++)
    {
        Console.WriteLine($"Номер лица: {i}");
        Console.WriteLine($"Имя и фамилия: {myPeople[i].FirstName} {myPeople[i].LastName}");
        Console.WriteLine($"Возраст: {myPeople[i].Age}");
        Console.WriteLine();
    }
}

static void MultiIndexerWithDataTable()
{
    // Создать простой объект DataTable с 3 столбцами.
    var myTable = new DataTable();
    myTable.Columns.Add(new DataColumn("FirstName"));
    myTable.Columns.Add(new DataColumn("LastName"));
    myTable.Columns.Add(new DataColumn("Age"));

    // Добавить строку в таблицу.
    myTable.Rows.Add("Мэл", "Эплби", 60);

    // Использовать многомерный индексатор для вывода деталей первой строки.
    Console.WriteLine($"Имя: {myTable.Rows[0][0]}");
    Console.WriteLine($"Фамилия: {myTable.Rows[0][1]}");
    Console.WriteLine($"Возраст: {myTable.Rows[0][2]}");
}