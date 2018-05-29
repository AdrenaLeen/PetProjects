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
using Notifications.Models;

namespace Notifications
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        readonly IList<Inventory> cars;

        public MainWindow()
        {
            InitializeComponent();
            cars = new List<Inventory>
            {
                new Inventory{CarId=1, Color="Голубой", Make="Chevy", PetName="Кит"},
                new Inventory{CarId=2, Color="Красный", Make="Ford", PetName="Красный всадник"}
            };
            cboCars.ItemsSource = cars;
        }
    }
}
