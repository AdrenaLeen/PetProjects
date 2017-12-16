using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessMultipleExceptions
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("***** Обработка множества исключений *****");
            Car myCar = new Car("Расти", 90);

            try
            {
                // Arg вызовет исключение выхода за пределы диапазона.
                myCar.Accelerate(-10);
            }
            catch
            {
                Console.WriteLine("Произошло что-то плохое...");
            }

            Console.ReadLine();
        }
    }
}
