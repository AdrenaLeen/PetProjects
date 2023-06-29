using System.Reflection;

Console.WriteLine("***** Стандартный домен приложения *****");
InitDAD();
DisplayDADStats();
ListAllAssembliesInAppDomain();
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
}

static void ListAllAssembliesInAppDomain()
{
    // Получить доступ к домену приложения для текущего потока.
    AppDomain defaultAD = AppDomain.CurrentDomain;

    // Извлечь все сборки, загруженные в стандартный домен приложения.
    IOrderedEnumerable<Assembly> loadedAssemblies = from a in defaultAD.GetAssemblies()
                                                    orderby a.GetName().Name
                                                    select a;

    Console.WriteLine($"***** Здесь сборки, загруженные в {defaultAD.FriendlyName} *****");
    foreach (Assembly a in loadedAssemblies)
    {
        Console.WriteLine($"-> Имя: {a.GetName().Name}");
        Console.WriteLine($"-> Версия: {a.GetName().Version}");
        Console.WriteLine();
    }
}

static void InitDAD()
{
    // Эта логика будет выводить имя любой сборки, загруженной в домен приложения после его создания.
    AppDomain defaultAD = AppDomain.CurrentDomain;
    defaultAD.AssemblyLoad += (o, s) => Console.WriteLine($"{s.LoadedAssembly.GetName().Name} загружена!");
}