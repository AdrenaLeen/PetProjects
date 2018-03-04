using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace StreamWriterReaderApp
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("***** StreamWriter / StreamReader *****");

            // Получить объект StreamWriter и записать строковые данные.
            using (StreamWriter writer = File.CreateText("reminders.txt"))
            {
                writer.WriteLine("Не забыть день матери в этом году...");
                writer.WriteLine("Не забыть день отца в этом году...");
                writer.WriteLine("Не забыть эти числа:");
                for (int i = 0; i < 10; i++) writer.Write($"{i} ");

                // Вставить новую строку.
                writer.Write(writer.NewLine);
            }
            Console.WriteLine("Создать файл и записать некоторые мысли...");

            Console.ReadLine();
        }
    }
}
