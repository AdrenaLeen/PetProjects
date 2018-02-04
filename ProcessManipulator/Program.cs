﻿using System;
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
    }
}
