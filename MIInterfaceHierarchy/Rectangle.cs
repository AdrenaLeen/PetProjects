namespace MiInterfaceHierarchy
{
    class Rectangle : IShape
    {
        public int GetNumberOfSides() => 4;

        public void Draw() => Console.WriteLine("Отрисовка...");

        public void Print() => Console.WriteLine("Печать...");
    }
}
