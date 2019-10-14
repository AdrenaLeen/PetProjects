using System;
using System.Data;
using System.Media;

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
            DataSet d = new DataSet();
            d.DisplayDefiningAssembly();

            // И в SoundPlayer!
            SoundPlayer sp = new SoundPlayer();
            sp.DisplayDefiningAssembly();

            // Использовать новую функциональность int.
            Console.WriteLine($"Значение myInt: {myInt}");
            Console.WriteLine($"Обратный порядок следования цифр myInt: {myInt.ReverseDigits()}");

            Console.ReadLine();
        }
    }
}
