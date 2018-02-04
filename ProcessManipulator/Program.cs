using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace ProcessManipulator
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("***** Процессы *****");
            ListAllRunningProcesses();
            GetSpecificProcess();

            // Запросить у пользователя PID и вывести набор активных потоков.
            Console.WriteLine("***** Введите PID процесса для исследования *****");
            Console.Write("PID: ");
            string pID = Console.ReadLine();
            int theProcID = int.Parse(pID);
            EnumThreadsForPid(theProcID);
            EnumModsForPid(theProcID);
            StartAndKillProcess();

            Console.ReadLine();
        }

        static void ListAllRunningProcesses()
        {
            // Получить все процессы на локальной машине, упорядоченные по PID.
            IOrderedEnumerable<Process> runningProcs = from proc in Process.GetProcesses(".") orderby proc.Id select proc;

            // Вывести для каждого процесса идентификатор PID и имя.
            foreach (Process p in runningProcs)
            {
                string info = string.Format($"-> PID: {p.Id}\tИмя: {p.ProcessName}");
                Console.WriteLine(info);
            }
            Console.WriteLine("************************************");
        }

        // Если процесс с PID, равным 987, не существует, сгенерировать исключение во время выполнения.
        static void GetSpecificProcess()
        {
            Process theProc = null;
            try
            {
                theProc = Process.GetProcessById(987);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void EnumThreadsForPid(int pID)
        {
            Process theProc = null;
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
            {
                string info = $"-> ID процесса: {pt.Id}\tВремя начала: {pt.StartTime.ToShortTimeString()}\tПриоритет: {pt.PriorityLevel}";
                Console.WriteLine(info);
            }
            Console.WriteLine("************************************");
        }

        static void EnumModsForPid(int pID)
        {
            Process theProc = null;
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
            foreach (ProcessModule pm in theMods)
            {
                string info = $"-> Имя модуля: {pm.ModuleName}";
                Console.WriteLine(info);
            }
            Console.WriteLine("************************************");
        }

        static void StartAndKillProcess()
        {
            Process ieProc = null;

            // Запустить Internet Explorer и перейти на сайт facebook.com с развёрнутым на весь экран окном.
            try
            {
                ProcessStartInfo startInfo = new ProcessStartInfo("IExplore.exe", "www.facebook.com");
                startInfo.WindowStyle = ProcessWindowStyle.Maximized;
                ieProc = Process.Start(startInfo);
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.Write($"--> Нажмите Enter, чтобы остановить {ieProc.ProcessName}...");
            Console.ReadLine();

            // Уничтожить процесс iexplore.exe.
            try
            {
                ieProc.Kill();
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
