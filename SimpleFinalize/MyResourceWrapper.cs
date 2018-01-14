using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
