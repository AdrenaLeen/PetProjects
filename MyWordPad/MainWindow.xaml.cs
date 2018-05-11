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

namespace MyWordPad
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

        private void FileExit_MouseEnter(object sender, MouseEventArgs e)
        {

        }

        private void FileExit_MouseLeave(object sender, MouseEventArgs e)
        {

        }

        private void FileExit_Click(object sender, RoutedEventArgs e)
        {
            // Закрыть это окно.
            Close();
        }

        private void ToolsSpellingHints_MouseEnter(object sender, MouseEventArgs e)
        {

        }

        private void ToolsSpellingHints_MouseLeave(object sender, MouseEventArgs e)
        {

        }

        private void ToolsSpellingHints_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
