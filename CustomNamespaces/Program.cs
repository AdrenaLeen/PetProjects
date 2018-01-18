using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyShapes;
using My3DShapes;
using System.Runtime.Serialization.Formatters.Binary;

// Устранить неоднозначность, используя специальный псевдоним.
using The3DHexagon = My3DShapes.Hexagon;

namespace CustomNamespaces
{
    class Program
    {
        static void Main()
        {
            // На самом деле здесь создаётся экземпляр класса My3DShapes.Hexagon.
            The3DHexagon h = new The3DHexagon();
            My3DShapes.Circle c = new My3DShapes.Circle();
            MyShapes.Square s = new MyShapes.Square();

            BinaryFormatter b = new BinaryFormatter();

            Console.ReadLine();
        }
    }
}
