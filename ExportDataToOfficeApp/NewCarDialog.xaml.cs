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
using System.Windows.Shapes;

namespace ExportDataToOfficeApp
{
    /// <summary>
    /// Логика взаимодействия для NewCarDialog.xaml
    /// </summary>
    public partial class NewCarDialog : Window
    {
        public Car theCar = null;

        public NewCarDialog()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            theCar = new Car() { PetName = txtCarName.Text, Make = ((ListBoxItem)lstMakes.SelectedValue).Content.ToString(), Color = ((ListBoxItem)lstColors.SelectedValue).Content.ToString() };
            DialogResult = true;
        }
    }
}
