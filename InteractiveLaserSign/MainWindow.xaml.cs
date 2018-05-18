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
using System.Windows.Media.Effects;

namespace InteractiveLaserSign
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

        private void Line1_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            // Изменить цвет при щелчке.
            Line1.Fill = new SolidColorBrush(Colors.Red);
        }

        private void Line2_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            // Размыть при щелчке.
            BlurEffect blur = new BlurEffect();
            blur.Radius = 10;
            Line2.Effect = blur;
        }
    }
}
