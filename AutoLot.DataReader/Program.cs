using Npgsql;

Console.WriteLine("***** Data Reader *****");

// Создать и открыть подключение.
using (var connection = new NpgsqlConnection())
{
    var connectionStringBuilder = new NpgsqlConnectionStringBuilder
    {
        Host = "localhost",
        Port = 5432,
        Database = "Autolot",
        Username = "postgres",
        Password = "Alias4.7"
    };
    connection.ConnectionString = connectionStringBuilder.ConnectionString;
    connection.Open();

    // Новая вспомогательная функция.
    ShowConnectionStatus(connection);

    // Создать объект команды SQL.
    string sql = "SELECT i.\"Id\", m.\"Name\" as \"Make\", i.\"Color\", i.\"PetName\" FROM \"Inventory\" i INNER JOIN \"Makes\" m on m.\"Id\" = i.\"MakeId\";";
    sql += "SELECT * FROM \"Customers\";";
    var myCommand = new NpgsqlCommand(sql, connection);
    using NpgsqlDataReader myDataReader = myCommand.ExecuteReader();
    do
    {
        // Пройти в цикле по результатам.
        while (myDataReader.Read())
        {
            for (int i = 0; i < myDataReader.FieldCount; i++)
                Console.Write(i != myDataReader.FieldCount - 1
                        ? $"{myDataReader.GetName(i)} = {myDataReader.GetValue(i)}, "
                        : $"{myDataReader.GetName(i)} = {myDataReader.GetValue(i)} ");
            Console.WriteLine();
        }
        Console.WriteLine();
    } while (myDataReader.NextResult());
}
Console.ReadLine();

static void ShowConnectionStatus(NpgsqlConnection connection)
{
    // Вывести различные сведения о текущем объекте подключения.
    Console.WriteLine("***** Информация о вашем объекте подключения *****");
    Console.WriteLine($"Местоположение базы данных: {connection.DataSource}");
    Console.WriteLine($"Имя базы данных: {connection.Database}");
    Console.WriteLine($"Таймаут: {connection.ConnectionTimeout}");
    Console.WriteLine($"Состояние: {connection.State}");
    Console.WriteLine();
}