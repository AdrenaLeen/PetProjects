using MagicEightBallServiceLib;
using System;
using System.ServiceModel;
using System.ServiceModel.Description;

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
                DisplayHostInfo(serviceHost);

                // Оставить службу функционирующей до тех пор, пока не будет нажата клавиша <Enter>.
                Console.WriteLine("Служба готова.");
                Console.WriteLine("Нажмите Enter, чтобы остановить службу.");
                Console.ReadLine();
            }
        }

        static void DisplayHostInfo(ServiceHost host)
        {
            Console.WriteLine();
            Console.WriteLine("***** Информация о хосте *****");

            foreach (ServiceEndpoint se in host.Description.Endpoints)
            {
                Console.WriteLine($"Адрес: {se.Address}");
                Console.WriteLine($"Привязка: {se.Binding.Name}");
                Console.WriteLine($"Контракт: {se.Contract.Name}");
                Console.WriteLine();
            }
            Console.WriteLine("**********************");
        }
    }
}
