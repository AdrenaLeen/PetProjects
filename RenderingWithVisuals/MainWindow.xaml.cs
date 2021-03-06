﻿using System;
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
using System.Globalization;

namespace RenderingWithVisuals
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MouseDown += MyVisualHost_MouseDown;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            const int textFontSize = 30;

            // Создать объект System.Windows.Media.FormattedText.
            FormattedText text = new FormattedText("Привет визуальному уровню!", new CultureInfo("en-us"), FlowDirection.LeftToRight, new Typeface(FontFamily, FontStyles.Italic, FontWeights.DemiBold, FontStretches.UltraExpanded), textFontSize, Brushes.Green, VisualTreeHelper.GetDpi(this).DpiScaleX);

            // Создать объект DrawingVisual и получить объект DrawingContext.
            DrawingVisual drawingVisual = new DrawingVisual();
            using (DrawingContext drawingContext = drawingVisual.RenderOpen())
            {
                // Вызвать любой из методов DrawingContext для визуализации данных.
                drawingContext.DrawRoundedRectangle(Brushes.Yellow, new Pen(Brushes.Black, 5), new Rect(5, 5, 450, 100), 20, 20);
                drawingContext.DrawText(text, new Point(20, 20));
            }

            // Динамически создать битовое изображение, используя данные в объекте DrawingVisual.
            RenderTargetBitmap bmp = new RenderTargetBitmap(500, 100, 100, 90, PixelFormats.Pbgra32);
            bmp.Render(drawingVisual);

            // Установить источник для элемента управления Image!
            myImage.Source = bmp;
        }

        private void MyVisualHost_MouseDown(object sender, MouseButtonEventArgs e)
        {
            // Выяснить, где пользователь выполнил щелчок.
            Point pt = e.GetPosition((UIElement)sender);

            // Вызвать вспомогательную функцию через делегат, чтобы посмотреть, был ли совершён щелчок на визуальном объекте.
            VisualTreeHelper.HitTest(this, null,
            MyCallback, new PointHitTestParameters(pt));
        }

        public HitTestResultBehavior MyCallback(HitTestResult result)
        {
            // Если щелчок был совершён на визуальном объекте, то переключиться между скошенной и нормальной визуализацией.
            if (result.VisualHit.GetType() == typeof(DrawingVisual))
            {
                if (((DrawingVisual)result.VisualHit).Transform == null) ((DrawingVisual)result.VisualHit).Transform = new SkewTransform(7, 7);
                else ((DrawingVisual)result.VisualHit).Transform = null;
            }

            // Сообщить методу HitTest() о прекращении углубления в визуальное дерево.
            return HitTestResultBehavior.Stop;
        }
    }
}
