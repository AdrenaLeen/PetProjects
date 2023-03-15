namespace MiInterfaceHierarchy
{
    class Square : IShape
    {
        // Использование явной реализации для устранения конфликта имен членов.
        void IPrintable.Draw()
        {
            // Вывести на принтер...
        }
        void IDrawable.Draw()
        {
            // Вывести на экран...
        }
        public void Print()
        {
            // Печатать...
        }

        public int GetNumberOfSides() => 4;
    }
}
