using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtensionMethods
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("***** Расширяющие методы *****");

            // В int появилась новая отличительная черта!
            int myInt = 12345678;
            myInt.DisplayDefiningAssembly();

            // То же и в DataSet!
            System.Data.DataSet d = new System.Data.DataSet();
            d.DisplayDefiningAssembly();

            // И в SoundPlayer!
            System.Media.SoundPlayer sp = new System.Media.SoundPlayer();
            sp.DisplayDefiningAssembly();

            // Использовать новую функциональность int.
            Console.WriteLine($"Значение myInt: {myInt}");
            Console.WriteLine($"Обратный порядок следования цифр myInt: {myInt.ReverseDigits()}");

            Console.ReadLine();
        }
    }
}
