using System.Diagnostics;

Console.WriteLine("***** Процессы *****");
ListAllRunningProcesses();
GetSpecificProcess();

// Запросить у пользователя PID и вывести набор активных потоков.
Console.WriteLine("***** Введите PID процесса для исследования *****");
Console.Write("PID: ");
string pID = Console.ReadLine() ?? "0";
int theProcID = int.Parse(pID);
EnumThreadsForPid(theProcID);
EnumModsForPid(theProcID);
StartAndKillProcess();
UseApplicationVerbs();

Console.ReadLine();

static void ListAllRunningProcesses()
{
    // Получить все процессы на локальной машине, упорядоченные по PID.
    IOrderedEnumerable<Process> runningProcs = from proc in Process.GetProcesses(".") orderby proc.Id select proc;

    // Вывести для каждого процесса идентификатор PID и имя.
    foreach (Process p in runningProcs) Console.WriteLine(string.Format($"-> PID: {p.Id}\tИмя: {p.ProcessName}"));
    Console.WriteLine("************************************");
    Console.WriteLine();
}

// Если процесс с PID, равным 987, не существует, сгенерировать исключение во время выполнения.
static void GetSpecificProcess()
{
    try
    {
        var theProc = Process.GetProcessById(987);
    }
    catch (ArgumentException ex)
    {
        Console.WriteLine(ex.Message);
    }
}

static void EnumThreadsForPid(int pID)
{
    Process theProc;
    try
    {
        theProc = Process.GetProcessById(pID);
    }
    catch (ArgumentException ex)
    {
        Console.WriteLine(ex.Message);
        return;
    }

    // Вывести статистические сведения по каждому потоку в указанном процессе.
    Console.WriteLine($"Здесь используемые потоки: {theProc.ProcessName}");
    ProcessThreadCollection theThreads = theProc.Threads;

    foreach (ProcessThread pt in theThreads)
        Console.WriteLine($"-> ID процесса: {pt.Id}\tВремя начала: {pt.StartTime.ToShortTimeString()}\tПриоритет: {pt.PriorityLevel}");
    Console.WriteLine("************************************");
    Console.WriteLine();
}

static void EnumModsForPid(int pID)
{
    Process theProc;
    try
    {
        theProc = Process.GetProcessById(pID);
    }
    catch (ArgumentException ex)
    {
        Console.WriteLine(ex.Message);
        return;
    }

    Console.WriteLine($"Здесь загруженные модули для: {theProc.ProcessName}");
    ProcessModuleCollection theMods = theProc.Modules;
    foreach (ProcessModule pm in theMods) Console.WriteLine($"-> Имя модуля: {pm.ModuleName}");
    Console.WriteLine("************************************");
    Console.WriteLine();
}

static void StartAndKillProcess()
{
    Process? proc = null;

    // Запустить Edge и перейти на сайт facebook.com с развернутым на весь экран окном.
    try
    {
        var startInfo = new ProcessStartInfo(@"C:\Program Files (x86)\Microsoft\Edge\Application\msedge.exe", "www.facebook.com")
        {
            WindowStyle = ProcessWindowStyle.Maximized
        };
        proc = Process.Start(startInfo);
    }
    catch (InvalidOperationException ex)
    {
        Console.WriteLine(ex.Message);
    }

    Console.Write($"--> Нажмите Enter, чтобы остановить {proc?.ProcessName}...");
    Console.ReadLine();

    // Уничтожить процесс iexplore.exe.
    try
    {
        proc?.Kill();
    }
    catch (InvalidOperationException ex)
    {
        Console.WriteLine(ex.Message);
    }
}

static void UseApplicationVerbs()
{
    int i = 0;
    var si = new ProcessStartInfo(@"D:\OneDrive\Documents\Проекты\Ксения Кузнецова\Аспирантура\Документы для поступления\Заявление на поступление в аспирантуру.docx");
    foreach (var verb in si.Verbs) Console.WriteLine($"  {i++}. {verb}");
    si.WindowStyle = ProcessWindowStyle.Maximized;
    si.Verb = "Edit";
    si.UseShellExecute = true;
    Process.Start(si);
}