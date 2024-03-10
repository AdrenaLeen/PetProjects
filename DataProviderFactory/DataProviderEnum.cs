namespace DataProviderFactory
{
    // OleDb поддерживается только в Windows, но не в .NET Core.
    enum DataProviderEnum
    {
        SqlServer,
#if PC
        OleDb,
#endif
        Odbc,
        PostgreSQL
    }
}
