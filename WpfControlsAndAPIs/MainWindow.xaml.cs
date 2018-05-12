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
using System.IO;
using System.Windows.Ink;

namespace WpfControlsAndAPIs
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // Установить режим Ink в качестве стандартного.
            myInkCanvas.EditingMode = InkCanvasEditingMode.Ink;
            inkRadio.IsChecked = true;
            comboColors.SelectedIndex = 0;
        }

        private void RadioButtonClicked(object sender, RoutedEventArgs e)
        {
            // В зависимости от того, какая кнопка отправила событие, поместить InkCanvas в нужный режим оперирования.
            switch ((sender as RadioButton)?.Content.ToString())
            {
                case "Режим пера!":
                    myInkCanvas.EditingMode = InkCanvasEditingMode.Ink;
                    break;

                case "Режим ластика!":
                    myInkCanvas.EditingMode = InkCanvasEditingMode.EraseByStroke;
                    break;

                case "Режим выбора!":
                    myInkCanvas.EditingMode = InkCanvasEditingMode.Select;
                    break;
            }
        }

        private void ColorChanged(object sender, SelectionChangedEventArgs e)
        {
            // Получить свойство Tag выбранного элемента StackPanel.
            string colorToUse = (comboColors.SelectedItem as StackPanel).Tag.ToString();

            // Изменить цвет, используемый для визуализации штрихов.
            myInkCanvas.DefaultDrawingAttributes.Color = (Color)ColorConverter.ConvertFromString(colorToUse);
        }

        private void SaveData(object sender, RoutedEventArgs e)
        {
            // Сохранить все данные InkCanvas в локальном файле.
            using (FileStream fs = new FileStream("StrokeData.bin", FileMode.Create))
            {
                myInkCanvas.Strokes.Save(fs);
                fs.Close();
            }
        }

        private void LoadData(object sender, RoutedEventArgs e)
        {
            // Наполнить StrokeCollection из файла.
            using (FileStream fs = new FileStream("StrokeData.bin", FileMode.Open, FileAccess.Read))
            {
                StrokeCollection strokes = new StrokeCollection(fs);
                myInkCanvas.Strokes = strokes;
            }
        }

        private void Clear(object sender, RoutedEventArgs e)
        {
            // Очистить все штрихи.
            myInkCanvas.Strokes.Clear();
        }
    }
}
