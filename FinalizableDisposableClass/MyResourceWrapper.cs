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
        // Используется для выяснения, вызывался ли метод Dispose().
        private bool disposed = false;

        // Сборщик мусора будет вызывать этот метод, если пользователь объекта забыл вызвать Dispose().
        ~MyResourceWrapper()
        {
            Console.Beep();
            // Очистить любые внутренние неуправляемые ресурсы.
            // **Не** вызывать Dispose() на управляемых объектах.
            // Вызвать вспомогательный метод.
            // Указание false означает, что очистку запустил сборщик мусора.
            CleanUp(false);
        }

        // Пользователь объекта будет вызывать этот метод для как можно более скорой очистки ресурсов.
        public void Dispose()
        {
            // Очистить неуправляемые ресурсы.
            // Вызвать Dispose() для других освобождаемых объектов, содержащихся внутри.

            // Вызвать вспомогательный метод. Указание true означает, что очистку запустил пользователь объекта.
            CleanUp(true);

            // Если пользователь вызвал Dispose(), то финализация не нужна, поэтому подавить её.
            GC.SuppressFinalize(this);
        }

        private void CleanUp(bool disposing)
        {
            // Удостовериться, не выполнялось ли уже освобождение.
            if (!disposed)
            {
                // Если disposing равно true, освободить все управляемые ресурсы.
                if (disposing)
                {
                    // Освободить управляемые ресурсы.
                }
                // Очистить неуправляемые ресурсы.
            }
            disposed = true;
        }
    }
}
