using System;
using System.Windows;
using System.Windows.Media;

namespace RenderingWithVisuals
{
    class CustomVisualFrameworkElement : FrameworkElement
    {
        // Коллекция всех визуальных объектов.
        readonly VisualCollection theVisuals;

        // Заполнить коллекцию VisualCollection несколькими объектами DrawingVisual.
        // Аргумент конструктора представляет владельца визуальных объектов.
        public CustomVisualFrameworkElement() => theVisuals = new VisualCollection(this) { AddRect(), AddCircle() };

        private Visual AddCircle()
        {
            DrawingVisual drawingVisual = new DrawingVisual();

            // Получить объект DrawingContext для создания нового содержимого.
            using (DrawingContext drawingContext = drawingVisual.RenderOpen())
            {
                // Создать круг и нарисовать его в DrawingContext.
                Rect rect = new Rect(new Point(160, 100), new Size(320, 80));
                drawingContext.DrawEllipse(Brushes.DarkBlue, null, new Point(70, 90), 40, 50);
            }
            return drawingVisual;
        }

        private Visual AddRect()
        {
            DrawingVisual drawingVisual = new DrawingVisual();
            using (DrawingContext drawingContext = drawingVisual.RenderOpen())
            {
                Rect rect = new Rect(new Point(160, 100), new Size(320, 80));
                drawingContext.DrawRectangle(Brushes.Tomato, null, rect);
            }
            return drawingVisual;
        }

        protected override int VisualChildrenCount => theVisuals.Count;

        protected override Visual GetVisualChild(int index)
        {
            // Значение должно быть больше нуля, поэтому разумно это проверить.
            if (index < 0 || index >= theVisuals.Count) throw new ArgumentOutOfRangeException();
            return theVisuals[index];
        }
    }
}
