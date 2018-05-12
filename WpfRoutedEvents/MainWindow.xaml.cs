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

namespace WpfRoutedEvents
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnClickMe_Click(object sender, RoutedEventArgs e)
        {
            // Делать что-нибудь, когда на кнопке произведён щелчок.
            MessageBox.Show("Кнопка нажата");
        }

        private void outerEllipse_MouseDown(object sender, MouseButtonEventArgs e)
        {
            // Изменить заголовок окна.
            Title = "Вы нажали на внешний эллипс!";
        }
    }
}
