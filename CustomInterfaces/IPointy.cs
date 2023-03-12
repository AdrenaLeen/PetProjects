namespace CustomInterfaces
{
    // Этот интерфейс определяет поведение "наличия вершин".
    // Поведение "наличия вершин" в виде свойства только для чтения.
    interface IPointy
    {
        byte Points { get; }
    }
}
