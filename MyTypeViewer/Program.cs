using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace MyTypeViewer
{
    class Program
    {
        static void Main()
        {
        }

        // Отобразить имена методов в типе.
        static void ListMethods(Type t)
        {
            Console.WriteLine("***** Методы *****");
            IEnumerable<string> methodNames = from n in t.GetMethods() select n.Name;
            foreach (string name in methodNames) Console.WriteLine($"->{name}");
            Console.WriteLine();
        }
    }
}
