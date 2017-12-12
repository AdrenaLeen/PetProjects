using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("***** Полиморфизм *****");
            Hexagon hex = new Hexagon("Бэт");
            hex.Draw();
            Circle cir = new Circle("Синди");
            // Вызывает реализацию базового класса!
            cir.Draw();

            // Создать массив совместимых с Shape объектов.
            Shape[] myShapes = {new Hexagon(), new Circle(), new Hexagon("Мик"), new Circle("Бэт"), new Hexagon("Линда")};

            // Пройти в цикле по всем элементам и взаимодействовать с полиморфным интерфейсом.
            foreach (Shape s in myShapes) s.Draw();

            // Здесь вызывается метод Draw(), определённый в классе ThreeDCircle.
            ThreeDCircle o = new ThreeDCircle();
            o.Draw();

            // Здесь вызывается метод Draw(), определённый в родительском классе!
            ((Circle)o).Draw();

            Console.ReadLine();
        }
    }
}
