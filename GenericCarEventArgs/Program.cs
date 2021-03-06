﻿using System;

namespace GenericCarEventArgs
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("***** События *****");
            // Создать объект Car обычным образом.
            Car c1 = new Car("СлагБаг", 100, 10);

            // Зарегистрировать обработчики событий.
            c1.AboutToBlow += CarIsAlmostDoomed;
            c1.AboutToBlow += CarAboutToBlow;
            EventHandler<CarEventArgs> d = new EventHandler<CarEventArgs>(CarExploded);
            c1.Exploded += d;

            Console.WriteLine("***** Увеличение скорости *****");
            for (int i = 0; i < 6; i++) c1.Accelerate(20);

            // Удалить метод CarExploded из списка вызовов.
            c1.Exploded -= CarExploded;

            Console.WriteLine("***** Увеличение скорости *****");
            for (int i = 0; i < 6; i++) c1.Accelerate(20);

            Console.ReadLine();
        }

        public static void CarAboutToBlow(object sender, CarEventArgs e)
        {
            // Просто для подстраховки перед приведением произвести проверку во время выполнения.
            if (sender is Car c) Console.WriteLine($"Критическое сообщение от {c.PetName}: {e.msg}");
        }

        public static void CarIsAlmostDoomed(object sender, CarEventArgs e) => Console.WriteLine($"=> Критическое сообщение от объекта Car: {e.msg}");

        public static void CarExploded(object sender, CarEventArgs e) => Console.WriteLine(e.msg);
    }
}
