﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDelegate
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("***** Делегаты *****");

            // Сначала создать объект Car.
            Car c1 = new Car("СлагБаг", 100, 10);
            // Теперь сообщить ему, какой метод вызывать, когда он пожелает отправить сообщение.
            // Зарегистрировать несколько обработчиков событий.
            c1.RegisterWithCarEngine(new Car.CarEngineHandler(OnCarEngineEvent));
            c1.RegisterWithCarEngine(new Car.CarEngineHandler(OnCarEngineEvent2));

            // Увеличить скорость (это инициирует события).
            Console.WriteLine("***** Увеличение скорости *****");
            for (int i = 0; i < 6; i++) c1.Accelerate(20);

            Console.ReadLine();
        }

        // Это цель для входящих событий.
        // Теперь есть два метода, которые будут вызываться Car при отправке уведомлений.
        public static void OnCarEngineEvent(string msg)
        {
            Console.WriteLine("***** Сообщение от объекта Car *****");
            Console.WriteLine($"=> {msg}");
            Console.WriteLine("***********************************");
        }

        public static void OnCarEngineEvent2(string msg)
        {
            Console.WriteLine($"=> {msg.ToUpper()}");
        }
    }
}
