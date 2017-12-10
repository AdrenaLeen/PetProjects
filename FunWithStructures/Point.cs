﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunWithStructures
{
    struct Point
    {
        // Поля структуры.
        public int X;
        public int Y;

        // Добавить 1 к позиции (X, Y).
        public void Increment()
        {
            X++; Y++;
        }

        // Вычесть 1 из позиции (X, Y).
        public void Decrement()
        {
            X--; Y--;
        }

        // Отобразить текущую позицию.
        public void Display()
        {
            Console.WriteLine($"X = {X}, Y = {Y}");
        }
    }
}
