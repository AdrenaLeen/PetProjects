using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValueAndReferenceTypes
{
    // Классы всегда являются ссылочными типами.
    class PointRef
    {
        // Те же самые члены, что и в структуре Point...
        public int X;
        public int Y;

        // Не забудьте изменить имя конструктора на PointRef!
        public PointRef(int XPos, int YPos)
        {
            X = XPos;
            Y = YPos;
        }

        public void Increment()
        {
            X++; Y++;
        }

        public void Decrement()
        {
            X--; Y--;
        }

        public void Display()
        {
            Console.WriteLine($"X = {X}, Y = {Y}");
        }
    }
}
