﻿using CustomCoversions;

Console.WriteLine("***** Преобразования *****");

// Создать экземпляр Rectangle.
var r = new Rectangle(15, 4);
Console.WriteLine(r.ToString());
r.Draw();
Console.WriteLine();

// Преобразовать r в Square на основе высоты Rectangle.
var s = (Square)r;
Console.WriteLine(s);
s.Draw();
Console.WriteLine();

// Преобразовать Rectangle в Square для вызова метода.
var rect = new Rectangle(10, 5);
DrawSquare((Square)rect);
Console.WriteLine();

// Преобразование int в Square.
var sq2 = (Square)90;
Console.WriteLine($"sq2 = {sq2}");

// Преобразование Square в int.
int side = (int)sq2;
Console.WriteLine($"Длина стороны sq2 = {side}");
Console.WriteLine();

var s3 = new Square { Length = 7 };

// Попытка сделать неявное приведение?
Rectangle rect2 = s3;
Console.WriteLine($"rect2 = {rect2}");

// Синтактсис явного преобразования также работает!
var s4 = new Square { Length = 3 };
var rect3 = (Rectangle)s4;
Console.WriteLine($"rect3 = {rect3}");

Console.ReadLine();

// Этот метод требует параметр типа Square.
static void DrawSquare(Square sq)
{
    Console.WriteLine(sq);
    sq.Draw();
}