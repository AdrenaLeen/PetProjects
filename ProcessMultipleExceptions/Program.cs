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
            catch (CarIsDeadException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }
            // Этот блок будет перехватывать любые исключения помимо CarIsDeadException и ArgumentOutOfRangeException.
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadLine();
        }
    }
}
