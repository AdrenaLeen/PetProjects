using System.Reflection;

Console.WriteLine("***** Добро пожаловать в MyTypeViewer *****");
do
{
    Console.Write("Введите имя типа для оценки или введите Q для выхода: ");

    // Получить имя типа.
    string typeName = Console.ReadLine() ?? string.Empty;

    // Пользователь желает завершить работу?
    if (typeName.Equals("Q", StringComparison.CurrentCultureIgnoreCase)) break;

    // Попробовать отобразить информацию о типе.
    try
    {
        var t = Type.GetType(typeName) ?? typeof(int);
        Console.WriteLine();
        ListVariousStats(t);
        ListFields(t);
        ListProps(t);
        ListMethods(t);
        ListInterfaces(t);
    }
    catch
    {
        Console.WriteLine("Не удаётся найти тип");
    }
} while (true);

// Отобразить имена методов в типе.
static void ListMethods(Type t)
{
    Console.WriteLine("***** Методы *****");
    IEnumerable<MethodInfo> methodNames = from n in t.GetMethods() select n;
    foreach (MethodInfo name in methodNames) Console.WriteLine($"->{name}");
    Console.WriteLine();
}

// Отобразить имена полей в типе.
static void ListFields(Type t)
{
    Console.WriteLine("***** Поля *****");
    IEnumerable<string> fieldNames = from f in t.GetFields() select f.Name;
    foreach (string name in fieldNames) Console.WriteLine($"->{name}");
    Console.WriteLine();
}

// Отобразить имена свойств в типе.
static void ListProps(Type t)
{
    Console.WriteLine("***** Свойства *****");
    IEnumerable<string> propNames = from p in t.GetProperties() select p.Name;
    foreach (string name in propNames) Console.WriteLine($"->{name}");
    Console.WriteLine();
}

// Отобразить имена интерфейсов, которые реализует тип.
static void ListInterfaces(Type t)
{
    Console.WriteLine("***** Интерфейсы *****");
    IEnumerable<Type> ifaces = from i in t.GetInterfaces() select i;
    foreach (Type i in ifaces) Console.WriteLine($"->{i.Name}");
    Console.WriteLine();
}

// Просто ради полноты картины.
static void ListVariousStats(Type t)
{
    Console.WriteLine("***** Различная статистика *****");
    Console.WriteLine($"Базовый класс: {t.BaseType}");
    Console.WriteLine($"Абстрактный? {t.IsAbstract}");
    Console.WriteLine($"Запечатанный? {t.IsSealed}");
    Console.WriteLine($"Обобщённый? {t.IsGenericTypeDefinition}");
    Console.WriteLine($"Класс? {t.IsClass}");
    Console.WriteLine();
}