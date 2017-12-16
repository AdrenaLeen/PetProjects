using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessMultipleExceptions
{
    class Program
    {
        // Передача ответственности.
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
                // Выполнить частичную обработку этой ошибки и передать ответственность.
                Console.WriteLine(e.Message);
                throw;
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
