using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomCoversions
{
    struct Rectangle
    {
        public int Width { get; set; }
        public int Height { get; set; }

        public Rectangle(int w, int h) : this()
        {
            Width = w;
            Height = h;
        }

        public void Draw()
        {
            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++) Console.Write("*");
                Console.WriteLine();
            }
        }

        public override string ToString() => $"[Ширина = {Width}; Высота = {Height}]";

        public static implicit operator Rectangle(Square s)
        {
            Rectangle r = new Rectangle();
            r.Height = s.Length;

            // Предположим, что ширина нового квадрата будет равна (Length x 2).
            r.Width = s.Length * 2;
            return r;
        }
    }
}
