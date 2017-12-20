using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomInterface
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("***** Интерфейсы *****");

            // Обратиться к свойству Points, определённому в интерфейсе IPointy.
            Hexagon hex = new Hexagon();
            Console.WriteLine($"Количество вершин: {hex.Points}");

            // Перехватить возможное исключение InvalidCastException.
            Circle c = new Circle("Лиза");
            IPointy itfPt = null;
            try
            {
                itfPt = (IPointy)c;
                Console.WriteLine(itfPt.Points);
            }
            catch (InvalidCastException e)
            {
                Console.WriteLine(e.Message);
            }

            // Можно ли hex2 трактовать как IPointy?
            Hexagon hex2 = new Hexagon("Питэр");
            IPointy itfPt2 = hex2 as IPointy;
            if (itfPt2 != null) Console.WriteLine($"Количество вершин: {itfPt2.Points}");
            else Console.WriteLine("Упс! Нет вершин...");

            // Создать массив элементов Shape.
            Shape[] myShapes = { new Hexagon(), new Circle(), new Triangle("Джои"), new Circle("ЙоЙо")};

            for (int i = 0; i < myShapes.Length; i++)
            {
                // Вспомните, что базовый класс Shape определяет абстрактный член Draw(), поэтому все фигуры знают, как себя рисовать.
                myShapes[i].Draw();

                // У каких фигур есть вершины?
                if (myShapes[i] is IPointy) Console.WriteLine($"-> Количество вершин: {((IPointy)myShapes[i]).Points}");
                else Console.WriteLine($"-> У {myShapes[i].PetName} нет вершин!");
                Console.WriteLine();

                // Можно ли нарисовать эту фигуру в трёхмерном виде?
                if (myShapes[i] is IDraw3D) DrawIn3D((IDraw3D)myShapes[i]);
            }

            // Получить первый элемент, имеющий вершины.
            // В целях безопасности не помешает проверить firstPointyItem на равенство null.
            IPointy firstPointyItem = FindFirstPointyShape(myShapes);
            Console.WriteLine($"У элемента {firstPointyItem.Points} вершин");

            Console.ReadLine();
        }

        // Будет рисовать любую фигуру, поддерживающую IDraw3D.
        static void DrawIn3D(IDraw3D itf3d)
        {
            Console.WriteLine("-> Отрисовка совместимых с IDraw3D типов");
            itf3d.Draw3D();
        }

        // Этот метод возвращает первый объект в массиве, который реализует интерфейс IPointy.
        static IPointy FindFirstPointyShape(Shape[] shapes)
        {
            foreach (Shape s in shapes)
            {
                if (s is IPointy) return s as IPointy;
            }
            return null;
        }
    }
}
