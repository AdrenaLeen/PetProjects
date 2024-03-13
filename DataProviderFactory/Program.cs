using System.Data.Common;
using System.Data.Odbc;
#if PC
using System.Data.OleDb;
#endif
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using DataProviderFactory;
using Npgsql;

Console.WriteLine("***** Фабрика поставщиков данных *****");

var (provider, connectionString) = GetProviderFromConfiguration();
DbProviderFactory? factory = GetDbProviderFactory(provider);

// Получить объект подключения.
using (DbConnection? connection = factory?.CreateConnection())
{
    if (connection == null)
    {
        Console.WriteLine("Не удалость создать объект подключения");
        return;
    }
    Console.WriteLine($"Ваш объект подключения: {connection.GetType().Name}");
    connection.ConnectionString = connectionString;
    connection.Open();

    // Вывести информацию об используемой версии SQL Server.
    if (connection is SqlConnection sqlConnection) Console.WriteLine(sqlConnection.ServerVersion);

    // Создать объект команды.
    DbCommand? command = factory?.CreateCommand();
    if (command == null)
    {
        Console.WriteLine("Не удалось создать объект команды");
        return;
    }
    Console.WriteLine($"Ваш объект команды: {command.GetType().Name}");
    command.Connection = connection;
    command.CommandText = @"SELECT i.""Id"", m.""Name"" FROM ""Inventory"" i INNER JOIN ""Makes"" m ON m.""Id"" = i.""MakeId""";

    // Вывести данные с помощью объекта чтения данных.
    using DbDataReader dataReader = command.ExecuteReader();
    Console.WriteLine($"Ваш объект чтения данных: {dataReader.GetType().Name}");
    Console.WriteLine("***** Inventory *****");
    while (dataReader.Read()) Console.WriteLine($"-> Машина #{dataReader["Id"]} - это {dataReader["Name"]}.");
}
Console.ReadLine();

static DbProviderFactory? GetDbProviderFactory(DataProviderEnum provider)
    => provider switch
    {
        DataProviderEnum.SqlServer => SqlClientFactory.Instance,
        DataProviderEnum.Odbc => OdbcFactory.Instance,
#if PC
        DataProviderEnum.OleDb => OleDbFactory.Instance,
#endif
        DataProviderEnum.PostgreSQL => NpgsqlFactory.Instance,
        _ => null
    };

static (DataProviderEnum provider, string? connectionString) GetProviderFromConfiguration()
{
    IConfiguration config = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json", true, true)
        .Build();
    var providerName = config["ProviderName"];
    if (Enum.TryParse(providerName, out DataProviderEnum provider))
    {
        return (provider, config[$"{providerName}:ConnectionString"]);
    };
    throw new Exception("Получено недопустимое значение поставщика данных.");
}