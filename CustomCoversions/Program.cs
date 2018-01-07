﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomCoversions
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("***** Преобразования *****");

            // Создать экземпляр Rectangle.
            Rectangle r = new Rectangle(15, 4);
            Console.WriteLine(r.ToString());
            r.Draw();
            Console.WriteLine();

            // Преобразовать r в Square на основе высоты Rectangle.
            Square s = (Square)r;
            Console.WriteLine(s);
            s.Draw();
            Console.WriteLine();

            // Преобразовать Rectangle в Square для вызова метода.
            Rectangle rect = new Rectangle(10, 5);
            DrawSquare((Square)rect);
            Console.WriteLine();

            // Преобразование int в Square.
            Square sq2 = (Square)90;
            Console.WriteLine($"sq2 = {sq2}");

            // Преобразование Square в int.
            int side = (int)sq2;
            Console.WriteLine($"Длина стороны sq2 = {side}");
            Console.WriteLine();

            Console.ReadLine();
        }

        // Этот метод требует параметр типа Square.
        static void DrawSquare(Square sq)
        {
            Console.WriteLine(sq);
            sq.Draw();
        }
    }
}
