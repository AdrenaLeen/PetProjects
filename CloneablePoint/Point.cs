﻿using System;
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
        public PointDescription desc = new PointDescription();

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
        public override string ToString()
        {
            return $"X = {X}; Y = {Y}; Название = {desc.PetName}; ID = {desc.PointID}";
        }

        // Возвратить копию текущего объекта.
        // Теперь необходимо скорректировать код для учёта члена PointDescription.
        public object Clone()
        {
            // Сначала получить поверхностную копию.
            Point newPoint = (Point)MemberwiseClone();

            // Затем восполнить пробелы.
            PointDescription currentDesc = new PointDescription();
            currentDesc.PetName = desc.PetName;
            newPoint.desc = currentDesc;

            return newPoint;
        }
    }
}