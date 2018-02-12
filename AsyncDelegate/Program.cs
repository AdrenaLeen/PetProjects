﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncDelegate
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("***** Асинхронный вызов делегата *****");

            // Print out the ID of the executing thread.
            Console.WriteLine("Main() invoked on thread {0}.",
              Thread.CurrentThread.ManagedThreadId);

            BinaryOp b = new BinaryOp(Add);
            IAsyncResult iftAR = b.BeginInvoke(10, 10, null, null);

            // This message will keep printing until
            // the Add() method is finished.
            while (!iftAR.IsCompleted)
            {
                Console.WriteLine("Doing more work in Main()!");
                Thread.Sleep(1000);
            }

            // Now we know the Add() method is complete.
            int answer = b.EndInvoke(iftAR);

            Console.WriteLine("10 + 10 is {0}.", answer);
            Console.ReadLine();
        }
    }
}