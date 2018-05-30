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
using System.Collections.ObjectModel;
using Notifications.Cmds;

namespace Notifications
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        readonly ObservableCollection<Inventory> cars;
        private ICommand changeColorCommand = null;
        private ICommand removeCarCommand = null;
        private ICommand addCarCommand = null;

        public MainWindow()
        {
            InitializeComponent();
            cars = new ObservableCollection<Inventory>
            {
                new Inventory{CarId=1, Color="Голубой", Make="Chevy", PetName="Кит", IsChanged=false},
                new Inventory{CarId=2, Color="Красный", Make="Ford", PetName="Красный всадник", IsChanged=false}
            };
            cboCars.ItemsSource = cars;
        }

        public ICommand ChangeColorCmd => changeColorCommand ?? (changeColorCommand = new ChangeColorCommand());
        public ICommand RemoveCarCmd => removeCarCommand ?? (removeCarCommand = new RemoveCarCommand(cars));
        public ICommand AddCarCmd => addCarCommand ?? (addCarCommand = new AddCarCommand(cars));
    }
}
