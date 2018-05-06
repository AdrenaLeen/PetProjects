using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace WpfAppAllCode
{
    class MainWindow : Window
    {
        // Наш элемент пользовательского интерфейса.
        private Button btnExitApp = new Button();

        public MainWindow(string windowTitle, int height, int width)
        {
            // Сконфигурировать кнопку и установить дочерний элемент управления.
            btnExitApp.Click += new RoutedEventHandler(btnExitApp_Clicked);
            btnExitApp.Content = "Завершить приложение";
            btnExitApp.Height = 25;
            btnExitApp.Width = 200;

            // Установить в качестве содержимого окна единственную кнопку.
            Content = btnExitApp;

            // Сконфигурировать окно.
            Title = windowTitle;
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            Height = height;
            Width = width;
        }

        private void btnExitApp_Clicked(object sender, RoutedEventArgs e)
        {
            // Закрыть окно.
            Close();
        }
    }
}
