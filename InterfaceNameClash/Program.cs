using System;

namespace InterfaceNameClash
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("***** Конфликт имён интерфейсов *****");
            // Все эти обращения приводят к вызову одного и того же метода Draw()!
            Octagon oct = new Octagon();
            IDrawToForm itfForm = oct;
            itfForm.Draw();
            IDrawToPrinter itfPrinter = oct;
            itfPrinter.Draw();
            IDrawToMemory itfMemory = oct;
            itfMemory.Draw();

            // Сокращённая форма, если переменная интерфейса не нужна.
            ((IDrawToPrinter)oct).Draw();

            // Можно было бы также использовать ключевое слово as.
            if (oct is IDrawToMemory) ((IDrawToMemory)oct).Draw();

            Console.ReadLine();
        }
    }
}
