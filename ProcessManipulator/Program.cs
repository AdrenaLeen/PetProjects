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
            Console.WriteLine("************************************\n");
        }
    }
}
