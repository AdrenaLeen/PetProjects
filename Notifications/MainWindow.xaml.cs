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

        private void btnChangeColor_Click(object sender, RoutedEventArgs e)
        {
            Inventory car = cars?.FirstOrDefault(x => x.CarId == ((Inventory)cboCars.SelectedItem)?.CarId);
            if (car != null) car.Color = "Розовый";
        }

        private void btnAddCar_Click(object sender, RoutedEventArgs e)
        {
            int maxCount = cars?.Max(x => x.CarId) ?? 0;
            cars?.Add(new Inventory { CarId = ++maxCount, Color = "Жёлтый", Make = "VW", PetName = "Пташка" });
        }
    }
}
