using System;
using System.Runtime.Remoting.Contexts;
using System.Threading;

namespace ObjectContextApp
{
    // SportsCarTS требует загрузки в синхронный контекст.
    [Synchronization]
    class SportsCarTS : ContextBoundObject
    {
        public SportsCarTS()
        {
            // Получить информацию о контексте и вывести идентификатор контекста.
            Context ctx = Thread.CurrentContext;
            Console.WriteLine($"Объект {ToString()} в контексте {ctx.ContextID}");
            foreach (IContextProperty itfCtxProp in ctx.ContextProperties) Console.WriteLine($"-> Свойство контекста: {itfCtxProp.Name}");
        }
    }
}
