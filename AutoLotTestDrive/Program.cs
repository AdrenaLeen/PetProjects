using AutoLotDAL.EF;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoLotTestDrive
{
    class Program
    {
        static void Main()
        {
            Database.SetInitializer(new DataInitializer());
            Console.WriteLine("***** ADO.NET EF Code First *****");
            Console.ReadLine();
        }
    }
}
