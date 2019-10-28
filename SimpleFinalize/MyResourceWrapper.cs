using System;

namespace SimpleFinalize
{
    // Переопределить System.Object.Finalize() посредством синтаксиса финализатора.
    class MyResourceWrapper
    {
        ~MyResourceWrapper()
        {
            // Очистить неуправляемые ресурсы.
            // Выдать звуковой сигнал при уничтожении (только в целях тестирования).
            Console.Beep();
        }
    }
}
