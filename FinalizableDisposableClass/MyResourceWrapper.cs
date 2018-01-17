using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalizableDisposableClass
{
    // Усовершенствованная оболочка для ресурсов.
    class MyResourceWrapper : IDisposable
    {
        // Сборщик мусора будет вызывать этот метод, если пользователь объекта забыл вызвать Dispose().
        ~MyResourceWrapper()
        {
            // Очистить любые внутренние неуправляемые ресурсы.
            // **Не** вызывать Dispose() на управляемых объектах.
        }

        // Пользователь объекта будет вызывать этот метод для как можно более скорой очистки ресурсов.
        public void Dispose()
        {
            // Очистить неуправляемые ресурсы.
            // Вызвать Dispose() для других освобождаемых объектов, содержащихся внутри.
            // Если пользователь вызвал Dispose(), то финализация не нужна, поэтому подавить её.
            GC.SuppressFinalize(this);
        }
    }
}
