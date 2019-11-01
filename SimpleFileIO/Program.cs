using System;
using System.IO;

namespace SimpleFileIO
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("***** Просто ввод-вывод с типом File *****");
            try
            {
                string[] myTasks = { "Починить раковину в ванной", "Позвонить Дэйву", "Позвонить маме и папе", "Поиграть в Xbox 360"};

                // Записать все данные в файл на диске D:.
                File.WriteAllLines(@"D:\tasks.txt", myTasks);

                // Прочитать все данные и вывести на консоль.
                foreach (string task in File.ReadAllLines(@"D:\tasks.txt")) Console.WriteLine($"TODO: {task}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadLine();
        }
    }
}
