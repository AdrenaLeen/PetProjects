using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoLotDAL.ConnectedLayer;
using AutoLotDAL.Models;
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
            if (userAnswer?.ToLower() == "n")
            {
                throwEx = false;
            }

            InventoryDAL dal = new InventoryDAL();
            dal.OpenConnection(ConfigurationManager.ConnectionStrings["AutoLotSqlProvider"].ConnectionString);

            // Обработать клиента с идентификатором 5 - в следующей строке кода должен быть указан идентификатор записи для клиента Гомер Симпсон.
            dal.ProcessCreditRisk(throwEx, 5);
            Console.WriteLine("Проверьте таблицу CreditRisk");
            Console.ReadLine();
        }
    }
}
