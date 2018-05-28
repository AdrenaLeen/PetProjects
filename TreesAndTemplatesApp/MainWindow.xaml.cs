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

namespace TreesAndTemplatesApp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string dataToShow = string.Empty;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnShowLogicalTree_Click(object sender, RoutedEventArgs e)
        {
            dataToShow = "";
            BuildLogicalTree(0, this);
            txtDisplayArea.Text = dataToShow;
        }

        void BuildLogicalTree(int depth, object obj)
        {
            // Добавить имя типа к переменной-члену dataToShow.
            dataToShow += $"{new string(' ', depth)}{obj.GetType().Name}\n";

            // Если элемент - не DependencyObject, то пропустить его.
            if (!(obj is DependencyObject)) return;

            // Выполнить рекурсивный вызов для каждого логического дочернего элемента.
            foreach (object child in LogicalTreeHelper.GetChildren((DependencyObject)obj))
            {
                BuildLogicalTree(depth + 5, child);
            }
        }

        private void btnShowVisualTree_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
