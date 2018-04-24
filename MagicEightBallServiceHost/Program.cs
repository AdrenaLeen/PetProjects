using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using MagicEightBallServiceLib;

namespace MagicEightBallServiceHost
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("***** Хост WCF *****");
            using (ServiceHost serviceHost = new ServiceHost(typeof(MagicEightBallService)))
            {
                // Открыть хост и начать прослушивание входящих сообщений.
                serviceHost.Open();
                
                // Оставить службу функционирующей до тех пор, пока не будет нажата клавиша <Enter>.
                Console.WriteLine("Служба готова.");
                Console.WriteLine("Нажмите Enter, чтобы остановить службу.");
                Console.ReadLine();
            }
        }
    }
}
