using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Remoting.Contexts;
using System.Threading;

namespace ObjectContextApp
{
    // Класс SportsCar не имеет никаких специальных контекстных потребностей и будет загружаться в стандартный контекст домена приложения.
    class SportsCar
    {
        public SportsCar()
        {
            // Получить информацию о контексте и вывести идентификатор контекста.
            Context ctx = Thread.CurrentContext;
            Console.WriteLine($"Объект {ToString()} в контексте {ctx.ContextID}");
            foreach (IContextProperty itfCtxProp in ctx.ContextProperties) Console.WriteLine($"-> Свойство контекста: {itfCtxProp.Name}");
        }
    }
}
