using System;
using System.Data.Common;
using System.Data.Entity.Infrastructure.Interception;

namespace AutoLotDAL.Interception
{
    public class ConsoleWriterInterceptor : IDbCommandInterceptor
    {
        private void WriteInfo(bool isAsync, string commandText) => Console.WriteLine($"Асинхронный: {isAsync}, Текст команды: {commandText}");

        public void NonQueryExecuting(DbCommand command, DbCommandInterceptionContext<int> interceptionContext) => WriteInfo(interceptionContext.IsAsync, command.CommandText);

        public void NonQueryExecuted(DbCommand command, DbCommandInterceptionContext<int> interceptionContext) => WriteInfo(interceptionContext.IsAsync, command.CommandText);

        public void ReaderExecuting(DbCommand command, DbCommandInterceptionContext<DbDataReader> interceptionContext) => WriteInfo(interceptionContext.IsAsync, command.CommandText);

        public void ReaderExecuted(DbCommand command, DbCommandInterceptionContext<DbDataReader> interceptionContext) => WriteInfo(interceptionContext.IsAsync, command.CommandText);

        public void ScalarExecuting(DbCommand command, DbCommandInterceptionContext<object> interceptionContext) => WriteInfo(interceptionContext.IsAsync, command.CommandText);

        public void ScalarExecuted(DbCommand command, DbCommandInterceptionContext<object> interceptionContext) => WriteInfo(interceptionContext.IsAsync, command.CommandText);
    }
}
