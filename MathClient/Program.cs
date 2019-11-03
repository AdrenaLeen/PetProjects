using MathClient.ServiceReference1;
using System;
using System.Threading;

namespace MathClient
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("***** Асинхронный вызов службы из клиента *****");
            using (BasicMathClient proxy = new BasicMathClient())
            {
                proxy.Open();

                // Суммировать числа в асинхронной манере с применением лямбда-выражения.
                IAsyncResult result = proxy.BeginAdd(2, 3, ar =>
                {
                    Console.WriteLine($"2 + 3 = {proxy.EndAdd(ar)}");
                }, null);

                while (!result.IsCompleted)
                {
                    Thread.Sleep(200);
                    Console.WriteLine("Клиент работает...");
                }
            }
            Console.ReadLine();
        }
    }
}
