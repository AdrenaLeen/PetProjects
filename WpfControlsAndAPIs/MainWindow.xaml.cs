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
            // TODO: Добавить сюда реализацию обработчика событий.
        }
    }
}
