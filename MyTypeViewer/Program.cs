﻿using System;
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

        // Отобразить имена полей в типе.
        static void ListFields(Type t)
        {
            Console.WriteLine("***** Поля *****");
            IEnumerable<string> fieldNames = from f in t.GetFields() select f.Name;
            foreach (string name in fieldNames) Console.WriteLine($"->{name}");
            Console.WriteLine();
        }

        // Отобразить имена свойств в типе.
        static void ListProps(Type t)
        {
            Console.WriteLine("***** Свойства *****");
            IEnumerable<string> propNames = from p in t.GetProperties() select p.Name;
            foreach (string name in propNames) Console.WriteLine($"->{name}");
            Console.WriteLine();
        }
    }
}
