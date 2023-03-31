namespace FinalizableDisposableClass
{
    // Усовершенствованная оболочка для ресурсов.
    class MyResourceWrapper : IDisposable
    {
        // Используется для выяснения, вызывался ли метод Dispose().
        bool disposed = false;

        // Сборщик мусора будет вызывать этот метод, если пользователь объекта забыл вызвать Dispose().
        ~MyResourceWrapper()
        {
            // Вызвать вспомогательный метод.
            // Указание false означает, что очистку запустил сборщик мусора.
            CleanUp(false);
        }

        public void Dispose()
        {
            // Вызвать вспомогательный метод. Указание true означает, что очистку запустил пользователь объекта.
            CleanUp(true);

            // Подавить финализацию.
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
