using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace InterfaceExtensions
{
    static class AnnoyingExtensions
    {
        public static void PrintDataAndBeep(this IEnumerable iterator)
        {
            foreach (var item in iterator)
            {
                Console.WriteLine(item);
                Console.Beep();
            }
        }
    }
}
