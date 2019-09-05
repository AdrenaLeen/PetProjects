namespace MIInterfaceHierarchy
{
    // Множественное наследование интерфейсов. Разрешено!
    interface IShape : IDrawable, IPrintable
    {
        int GetNumberOfSides();
    }
}
