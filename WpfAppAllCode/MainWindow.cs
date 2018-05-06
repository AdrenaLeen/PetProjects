using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfAppAllCode
{
    class MainWindow : Window
    {
        public MainWindow(string windowTitle, int height, int width)
        {
            Title = windowTitle;
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            Height = height;
            Width = width;
        }
    }
}
