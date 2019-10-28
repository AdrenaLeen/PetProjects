using System;

namespace SimpleDispose
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("***** Освобождение объектов *****\n");

            // Создать освобождаемый объект и вызвать метод Dispose() для освобождения любых внутренних ресурсов.
            // Метод Dispose() вызывается автоматически при выходе за пределы области действия using.
            // Использование списка с разделителями-запятыми для объявления нескольких объектов, подлежащих освобождению.
            using (MyResourceWrapper rw = new MyResourceWrapper(), rw2 = new MyResourceWrapper())
            {
                // Работать с объектами rw и rw2.
            }

            Console.ReadLine();
        }
    }
}
