﻿using CarLibrary;
using System;

namespace CShaprCarClient
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("***** Клиентское приложение C# CarLibrary *****");
            // Создать объект SportsCar.
            SportsCar viper = new SportsCar("Вайпер", 240, 40);
            viper.TurboBoost();

            // Создать объект MiniVan.
            MiniVan mv = new MiniVan();
            mv.TurboBoost();

            Console.WriteLine("Готово. Нажмите любую клавишу для завершения");
            Console.ReadLine();
        }
    }
}
