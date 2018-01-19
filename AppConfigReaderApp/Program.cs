using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace AppConfigReaderApp
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("***** Чтение данных <appSettings> *****");
            // Извлечь специальные данные из файла *.config.
            AppSettingsReader ar = new AppSettingsReader();
            int numbOfTimes = (int)ar.GetValue("RepeatCount", typeof(int));
            string textColor = (string)ar.GetValue("TextColor", typeof(string));
            Console.ForegroundColor = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), textColor);
            // Вывести сообщение нужное количество раз.
            for (int i = 0; i < numbOfTimes; i++) Console.WriteLine("Привет!");
            Console.ReadLine();
        }
    }
}
