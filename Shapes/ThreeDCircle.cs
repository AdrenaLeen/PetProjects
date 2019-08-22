using System;

namespace Shapes
{
    // Этот класс расширяет Circle и скрывает унаследованный метод Draw().
    class ThreeDCircle : Circle
    {
        // Скрыть свойство PetName, определённое выше в иерархии.
        public new string PetName { get; set; }

        // Скрыть любую реализацию Draw(), находящуюся выше в иерархии.
        public new void Draw() => Console.WriteLine("Отрисовка 3D круга");
    }
}
