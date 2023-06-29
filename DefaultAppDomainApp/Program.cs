using System.Reflection;
using System.Runtime.Loader;

Console.WriteLine("***** Стандартный домен приложения *****");
DisplayDADStats();
ListAllAssembliesInAppDomain();
LoadAdditionalAssembliesDifferentContexts();
LoadAdditionalAssembliesSameContext();
Console.ReadLine();

static void DisplayDADStats()
{
    // Получить доступ к домену приложения для текущего потока.
    AppDomain defaultAD = AppDomain.CurrentDomain;

    // Вывести разнообразные статистические данные об этом домене.
    Console.WriteLine($"Дружественное имя этого домена: {defaultAD.FriendlyName}");
    Console.WriteLine($"Идентификатор домена в этом процессе: {defaultAD.Id}");
    Console.WriteLine($"Является ли стандартным доменом?: {defaultAD.IsDefaultAppDomain()}");
    Console.WriteLine($"Базовый каталог этого домена: {defaultAD.BaseDirectory}");
    Console.WriteLine("Информация о настройке этого домена:");
    Console.WriteLine($"Базовый каталог приложения: {defaultAD.SetupInformation.ApplicationBase}");
    Console.WriteLine($"Целевая платформа: {defaultAD.SetupInformation.TargetFrameworkName}");
    Console.WriteLine();
}

static void ListAllAssembliesInAppDomain()
{
    // Получить доступ к домену приложения для текущего потока.
    AppDomain defaultAD = AppDomain.CurrentDomain;

    // Извлечь все сборки, загруженные в стандартный домен приложения.
    IOrderedEnumerable<Assembly> loadedAssemblies = defaultAD.GetAssemblies().OrderBy(x => x.GetName().Name);

    Console.WriteLine($"***** Здесь сборки, загруженные в {defaultAD.FriendlyName} *****");
    foreach (Assembly a in loadedAssemblies) Console.WriteLine($"-> Имя, версия: {a.GetName().Name}:{a.GetName().Version}");
    Console.WriteLine();
}

static void LoadAdditionalAssembliesDifferentContexts()
{
    var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ClassLibrary.dll");
    var lc1 = new AssemblyLoadContext("NewContext1", false);
    var cl1 = lc1.LoadFromAssemblyPath(path);
    var c1 = cl1.CreateInstance("ClassLibrary.Car");
    var lc2 = new AssemblyLoadContext("NewContext2", false);
    var cl2 = lc2.LoadFromAssemblyPath(path);
    var c2 = cl2.CreateInstance("ClassLibrary.Car");
    Console.WriteLine("***** Загрузка дополнительных сборок в различных контекстах *****");
    Console.WriteLine($"Assembly1 Equals(Assembly2) {cl1.Equals(cl2)}");
    Console.WriteLine($"Assembly1 == Assembly2 {cl1 == cl2}");
    Console.WriteLine($"Class1.Equals(Class2) {c1?.Equals(c2)}");
    Console.WriteLine($"Class1 == Class2 {c1 == c2}");
    Console.WriteLine();
}

static void LoadAdditionalAssembliesSameContext()
{
    var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ClassLibrary.dll");
    var lc1 = new AssemblyLoadContext(null, false);
    var cl1 = lc1.LoadFromAssemblyPath(path);
    var c1 = cl1.CreateInstance("ClassLibrary.Car");
    var cl2 = lc1.LoadFromAssemblyPath(path);
    var c2 = cl2.CreateInstance("ClassLibrary.Car");
    Console.WriteLine("***** Загрузка дополнительных сборок в различных контекстах *****");
    Console.WriteLine($"Assembly1 Equals(Assembly2) {cl1.Equals(cl2)}");
    Console.WriteLine($"Assembly1 == Assembly2 {cl1 == cl2}");
    Console.WriteLine($"Class1.Equals(Class2) {c1?.Equals(c2)}");
    Console.WriteLine($"Class1 == Class2 {c1 == c2}");
}