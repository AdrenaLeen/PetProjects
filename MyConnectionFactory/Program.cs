using Microsoft.Data.SqlClient;
using MyConnectionFactory;
using System.Data;
using System.Data.Odbc;
#if PC
using System.Data.OleDb;
#endif

Console.WriteLine("**** Очень простая фабрика подключений *****");

Setup(DataProviderEnum.SqlServer);
#if PC
// Не поддерживается в macOS.
Setup(DataProviderEnum.OleDb);
#endif
Setup(DataProviderEnum.Odbc);
Setup(DataProviderEnum.None);

Console.ReadLine();

static void Setup(DataProviderEnum provider)
{
    // Получить конкретное подключение.
    IDbConnection? myConnection = GetConnection(provider);
    Console.WriteLine($"Ваше соединение: {myConnection?.GetType().Name ?? "нераспознанный тип"}");
    // Открыть, использовать и закрыть подключение...
}

// Этот метод возвращает конкретный объект подключения на основе значения перечисления DataProvider.
static IDbConnection? GetConnection(DataProviderEnum dataProvider) => dataProvider switch
{
    DataProviderEnum.SqlServer => new SqlConnection(),
#if PC
    // Не поддерживается в macOS.
    DataProviderEnum.OleDb => new OleDbConnection(),
#endif
    DataProviderEnum.Odbc => new OdbcConnection(),
    _ => null,
};