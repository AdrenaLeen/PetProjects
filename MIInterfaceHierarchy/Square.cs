namespace MIInterfaceHierarchy
{
    class Square : IShape
    {
        // Использование явной реализации для устранения конфликта имён членов.
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

        public int GetNumberOfSides()
        {
            return 4;
        }
    }
}
