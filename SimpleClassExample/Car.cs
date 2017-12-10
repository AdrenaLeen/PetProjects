﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleClassExample
{
    class Car
    {
        // 'Состояние' объекта Car.
        public string petName;
        public int currSpeed;

        // Специальный стандартный конструктор.
        public Car()
        {
            petName = "Чак";
            currSpeed = 10;
        }

        // Функциональность Car.
        public void PrintState()
        {
            Console.WriteLine($"{petName} едет со скоростью {currSpeed} км/ч.");
        }

        public void SpeedUp(int delta)
        {
            currSpeed += delta;
        }
    }
}
