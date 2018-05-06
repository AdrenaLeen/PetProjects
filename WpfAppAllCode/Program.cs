﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace WpfAppAllCode
{
    class Program : Application
    {
        [STAThread]
        static void Main()
        {
            // Обработать события Startup и Exit и затем запустить приложение.
            Program app = new Program();
            app.Startup += AppStartUp;
            app.Exit += AppExit;

            // Инициирует событие Startup.
            app.Run();
        }

        static void AppExit(object sender, ExitEventArgs e)
        {
            MessageBox.Show("Приложение завершило работу.");
        }

        static void AppStartUp(object sender, StartupEventArgs e)
        {
            // Создать объект Window и установить некоторые базовые свойства.
            Window mainWindow = new Window();
            mainWindow.Title = "Моё первое приложение WPF!";
            mainWindow.Height = 200;
            mainWindow.Width = 300;
            mainWindow.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            mainWindow.Show();
        }
    }
}
