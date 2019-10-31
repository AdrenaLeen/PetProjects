using System;
using System.Runtime.Serialization.Formatters.Binary;

// Устранить неоднозначность, используя специальный псевдоним.
using The3DHexagon = Chapter14.My3DShapes.Hexagon;

namespace CustomNamespaces
{
    class Program
    {
        static void Main()
        {
            // На самом деле здесь создаётся экземпляр класса My3DShapes.Hexagon.
            The3DHexagon h = new The3DHexagon();
            Chapter14.My3DShapes.Circle c = new Chapter14.My3DShapes.Circle();
            MyShapes.Square s = new MyShapes.Square();

            BinaryFormatter b = new BinaryFormatter();

            Console.ReadLine();
        }
    }
}
