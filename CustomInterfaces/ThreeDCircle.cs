namespace CustomInterfaces
{
    class ThreeDCircle : Circle, IDraw3D
    {
        // Скрыть свойство PetName, определённое выше в иерархии.
        public new string PetName { get; set; } = string.Empty;

        // Скрыть любую реализацию Draw(), находящуюся выше в иерархии.
        public new static void Draw() => Console.WriteLine("Отрисовка 3D круга");

        public void Draw3D() => Console.WriteLine("Отрисовка круга в 3D!");
    }
}
