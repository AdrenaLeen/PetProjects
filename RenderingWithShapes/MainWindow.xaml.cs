using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RenderingWithShapes
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private enum SelectedShape
        {
            Circle, Rectangle, Line
        }

        private SelectedShape currentShape;
        private bool isFlipped = false;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void canvasDrawingArea_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Shape shapeToRender = null;

            // Сконфигурировать корректную фигуру для рисования.
            switch (currentShape)
            {
                case SelectedShape.Circle:
                    shapeToRender = new Ellipse() { Height = 35, Width = 35 };

                    // Создать кисть RadialGradientBrush в коде.
                    RadialGradientBrush brush = new RadialGradientBrush();
                    brush.GradientStops.Add(new GradientStop((Color)ColorConverter.ConvertFromString("#FF87E71B"), 0.589));
                    brush.GradientStops.Add(new GradientStop((Color)ColorConverter.ConvertFromString("#FF2BA92B"), 0));
                    brush.GradientStops.Add(new GradientStop((Color)ColorConverter.ConvertFromString("#FF34B71B"), 1));
                    shapeToRender.Fill = brush;
                    break;
                case SelectedShape.Rectangle:
                    shapeToRender = new Rectangle() { Fill = Brushes.Red, Height = 35, Width = 35, RadiusX = 10, RadiusY = 10 };
                    break;
                case SelectedShape.Line:
                    shapeToRender = new Line()
                    {
                        Stroke = Brushes.Blue,
                        StrokeThickness = 10,
                        X1 = 0,
                        X2 = 50,
                        Y1 = 0,
                        Y2 = 50,
                        StrokeStartLineCap = PenLineCap.Triangle,
                        StrokeEndLineCap = PenLineCap.Round
                    };
                    break;
                default:
                    return;
            }

            // isFlipped - закрытое булевское поле. Его значение переключается при щелчке на кнопке переключения.
            if (isFlipped)
            {
                RotateTransform rotate = new RotateTransform(-180);
                shapeToRender.RenderTransform = rotate;
            }

            // Установить верхний левый угол для рисования на холсте.
            Canvas.SetLeft(shapeToRender, e.GetPosition(canvasDrawingArea).X);
            Canvas.SetTop(shapeToRender, e.GetPosition(canvasDrawingArea).Y);

            // Нарисовать фигуру.
            canvasDrawingArea.Children.Add(shapeToRender);
        }

        private void circleOption_Click(object sender, RoutedEventArgs e)
        {
            currentShape = SelectedShape.Circle;
        }

        private void rectOption_Click(object sender, RoutedEventArgs e)
        {
            currentShape = SelectedShape.Rectangle;
        }

        private void lineOption_Click(object sender, RoutedEventArgs e)
        {
            currentShape = SelectedShape.Line;
        }

        private void canvasDrawingArea_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            // Сначала получить координаты X,Y позиции, где пользователь выполнил щелчок.
            Point pt = e.GetPosition((Canvas)sender);

            // Использовать метод HitTest() класса VisualTreeHelper, чтобы выяснить, щёлкнул ли пользователь на элементе внутри Canvas.
            HitTestResult result = VisualTreeHelper.HitTest(canvasDrawingArea, pt);

            // Если переменная result не равна null, то щелчок произведён на фигуре!
            // Получить фигуру, на которой совершён щелчок, и удалить её из Canvas.
            if (result != null) canvasDrawingArea.Children.Remove(result.VisualHit as Shape);
        }

        private void flipCanvas_Click(object sender, RoutedEventArgs e)
        {
            if (flipCanvas.IsChecked == true)
            {
                RotateTransform rotate = new RotateTransform(-180);
                canvasDrawingArea.LayoutTransform = rotate;
                isFlipped = true;
            }
            else
            {
                canvasDrawingArea.LayoutTransform = null;
                isFlipped = false;
            }
        }
    }
}
