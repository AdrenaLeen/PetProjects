using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.ComponentModel;
using System.Windows.Input;

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

            Closing += MainWindow_Closing;
            Closed += MainWindow_Closed;
            MouseMove += MainWindow_MouseMove;
            KeyDown += MainWindow_KeyDown;
        }

        private void btnExitApp_Clicked(object sender, RoutedEventArgs e)
        {
            // Указал ли пользователь /godmode?
            if ((bool)Application.Current.Properties["GodMode"]) MessageBox.Show("Читер!");

            // Закрыть окно.
            Close();
        }

        private void MainWindow_Closing(object sender, CancelEventArgs e)
        {
            // Выяснить, действительно ли пользователь желает закрыть окно.
            string msg = "Хотите ли вы закрыть окно без сохранения?";
            MessageBoxResult result = MessageBox.Show(msg, "Моё приложение", MessageBoxButton.YesNo, MessageBoxImage.Warning);

            // Если пользователь не желает закрывать окно, то отменить закрытие.
            if (result == MessageBoxResult.No) e.Cancel = true;
        }

        private void MainWindow_Closed(object sender, EventArgs e)
        {
            MessageBox.Show("Увидимся!");
        }

        private void MainWindow_MouseMove(object sender, MouseEventArgs e)
        {
            // Отобразить в заголовке окна текущую позицию (x, y) курсора мыши.
            Title = e.GetPosition(this).ToString();
        }

        private void MainWindow_KeyDown(object sender, KeyEventArgs e)
        {
            // Отобразить на кнопке нажатую клавишу.
            btnExitApp.Content = e.Key.ToString();
        }
    }
}
