namespace OverloadedOps
{
    // Более интеллектуальный тип Point.
    public class Point : IComparable<Point>
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Point(int xPos, int yPos)
        {
            X = xPos;
            Y = yPos;
        }

        public override string ToString() => $"[{X}, {Y}]";

        // Перегруженная операция +
        public static Point operator +(Point p1, Point p2) => new(p1.X + p2.X, p1.Y + p2.Y);

        // Перегруженная операция -
        public static Point operator -(Point p1, Point p2) => new(p1.X - p2.X, p1.Y - p2.Y);

        public static Point operator +(Point p1, int change) => new(p1.X + change, p1.Y + change);

        public static Point operator +(int change, Point p1) => new(p1.X + change, p1.Y + change);

        // Добавить 1 к значениям X/Y входного объекта Point.
        public static Point operator ++(Point p1) => new(p1.X + 1, p1.Y + 1);

        // Вычесть 1 из значений X/Y входного объекта Point.
        public static Point operator --(Point p1) => new(p1.X - 1, p1.Y - 1);

        public override bool Equals(object? o) => o?.ToString() == ToString();

        public override int GetHashCode() => ToString().GetHashCode();

        // Теперь перегрузить операции == и !=.
        public static bool operator ==(Point p1, Point p2) => p1.Equals(p2);

        public static bool operator !=(Point p1, Point p2) => !p1.Equals(p2);

        public int CompareTo(Point? other)
        {
            if (X > other?.X && Y > other.Y) return 1;
            if (X < other?.X && Y < other.Y) return -1;
            else return 0;
        }

        public static bool operator <(Point p1, Point p2) => (p1.CompareTo(p2) < 0);

        public static bool operator >(Point p1, Point p2) => (p1.CompareTo(p2) > 0);

        public static bool operator <=(Point p1, Point p2) => (p1.CompareTo(p2) <= 0);

        public static bool operator >=(Point p1, Point p2) => (p1.CompareTo(p2) >= 0);
    }
}
