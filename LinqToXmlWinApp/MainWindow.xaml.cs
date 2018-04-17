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

namespace LinqToXmlWinApp
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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // Отобразить текущий документ XML склада в элементе управления TextBox.
            txtInventory.Text = LinqToXmlObjectModel.GetXmlInventory().ToString();
        }

        private void btnAddNewItem_Click(object sender, RoutedEventArgs e)
        {
            // Добавить к документу новый элемент.
            LinqToXmlObjectModel.InsertNewElement(txtMake.Text, txtColor.Text, txtPetName.Text);

            // Отобразить текущий документ XML для склада в элементе управления TextBox.
            txtInventory.Text = LinqToXmlObjectModel.GetXmlInventory().ToString();
        }

        private void btnLookUpColors_Click(object sender, RoutedEventArgs e)
        {
            LinqToXmlObjectModel.LookUpColorsForMake(txtMakeToLookUp.Text);
        }
    }
}
