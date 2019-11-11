using AutoLotDAL.ConnectedLayer;
using System;
using System.Configuration;

namespace AdoNetTransaction
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("***** Простой пример транзакции *****");

            // Просто способ позволить транзакции успешно выполниться или отказать.
            bool throwEx = true;

            Console.Write("Генерировать ли исключение (Y или N): ");
            string userAnswer = Console.ReadLine();
            if (userAnswer?.ToLower() == "n") throwEx = false;

            InventoryDAL dal = new InventoryDAL();
            dal.OpenConnection(ConfigurationManager.ConnectionStrings["AutoLotSqlProvider"].ConnectionString);

            // Обработать клиента 1 - ввести идентификатор клиента, подлежащего перемещению.
            dal.ProcessCreditRisk(throwEx, 1);
            Console.WriteLine("Проверьте таблицу CreditRisk");
            Console.ReadLine();
        }
    }
}
