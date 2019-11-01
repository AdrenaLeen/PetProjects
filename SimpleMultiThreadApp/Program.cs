using System;
using System.Threading;
using System.Windows.Forms;

namespace SimpleMultiThreadApp
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("***** Потоки *****");
            Console.Write("Вы хотите [1] или [2] потока? ");
            string threadCount = Console.ReadLine();

            // Назначить имя текущему потоку.
            Thread primaryThread = Thread.CurrentThread;
            primaryThread.Name = "Primary";

            // Вывести информацию о потоке.
            Console.WriteLine($"-> {Thread.CurrentThread.Name} выполняет Main()");

            // Создать рабочий класс.
            Printer p = new Printer();

            switch (threadCount)
            {
                case "2":
                    // Создать поток.
                    Thread backgroundThread = new Thread(new ThreadStart(p.PrintNumbers))
                    {
                        Name = "Secondary"
                    };
                    backgroundThread.Start();
                    break;
                case "1":
                    p.PrintNumbers();
                    break;
                default:
                    Console.WriteLine("Я не знаю, чего вы хотите... Вы получаете 1 поток.");
                    // Переход к варианту с одним потоком.
                    goto case "1";
            }

            // Выполнить некоторую дополнительную работу.
            MessageBox.Show("Я занят!", "Работа в основном потоке...");
            Console.ReadLine();
        }
    }
}
