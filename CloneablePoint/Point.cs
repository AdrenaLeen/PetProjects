namespace CloneablePoint
{
    // Теперь Point поддерживает способность клонирования.
    class Point : ICloneable
    {
        public int X { get; set; }
        public int Y { get; set; }
        public PointDescription desc = new();

        public Point(int xPos, int yPos, string petName)
        {
            X = xPos;
            Y = yPos;
            desc.PetName = petName;
        }
        public Point(int xPos, int yPos)
        {
            X = xPos;
            Y = yPos;
        }
        public Point() { }

        // Переопределить Object.ToString().
        public override string ToString() => $"X = {X}; Y = {Y}; Название = {desc.PetName}; ID = {desc.PointID}";

        // Возвратить копию текущего объекта.
        // Теперь необходимо скорректировать код для учёта члена PointDescription.
        public object Clone()
        {
            // Сначала получить поверхностную копию.
            var newPoint = (Point)MemberwiseClone();

            // Затем восполнить пробелы.
            var currentDesc = new PointDescription
            {
                PetName = desc.PetName
            };
            newPoint.desc = currentDesc;

            return newPoint;
        }
    }
}
