using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloneablePoint
{
    // Теперь Point поддерживает способность клонирования.
    class Point : ICloneable
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Point(int xPos, int yPos)
        {
            X = xPos;
            Y = yPos;
        }
        public Point() { }

        // Переопределить Object.ToString().
        public override string ToString()
        {
            return $"X = {X}; Y = {Y}";
        }

        // Возвратить копию текущего объекта.
        public object Clone()
        {
            return new Point(X, Y);
        }
    }
}
