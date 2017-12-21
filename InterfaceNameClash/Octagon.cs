using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceNameClash
{
    class Octagon : IDrawToForm, IDrawToMemory, IDrawToPrinter
    {
        // Явно привязать реализации Draw() к конкретным интерфейсам.
        void IDrawToForm.Draw()
        {
            Console.WriteLine("Вывод на форму...");
        }

        void IDrawToMemory.Draw()
        {
            Console.WriteLine("Вывод в память...");
        }

        void IDrawToPrinter.Draw()
        {
            Console.WriteLine("Вывод на принтер...");
        }
    }
}
